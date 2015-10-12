//-----------------------------------------------------------------------
// <copyright file="LexwareGlobalDbContext.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;

using FluentNHibernate.Cfg;

using FubarDev.Lexware.Database.NhSupport;

using JetBrains.Annotations;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Event;
using NHibernate.Linq;

using GlobalPoco = FubarDev.Lexware.Database.Global;

namespace FubarDev.Lexware.Database
{
    /// <summary>
    /// Datenbank-Kontext über den auf die Daten in der Lexware-Datenbank zugegriffen wird
    /// </summary>
    public sealed class LexwareGlobalDbContext
    {
        private readonly ConcurrentDictionary<SessionFactoryKey, ISessionFactory> _userSessionFactory = new ConcurrentDictionary<SessionFactoryKey, ISessionFactory>(new SessionFactoryKeyComparer());

        private readonly IStatelessSession _session;

        private NetworkCredential _superUserLogin;

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="LexwareGlobalDbContext"/> Klasse.
        /// </summary>
        /// <param name="configurationProvider">Der für den Verbindungsaufbau zu verwendende <see cref="IConfigurationProvider"/></param>
        public LexwareGlobalDbContext(IConfigurationProvider configurationProvider)
        {
            ConfigurationProvider = configurationProvider;
            ReadOnlyLogin = new NetworkCredential("_login_", "92ab346d1c02cffc");
            ReadOnlySessionFactory = CreateSessionFactory(ReadOnlyLogin, null);
            _session = ReadOnlySessionFactory.OpenStatelessSession();
        }

        /// <summary>
        /// Holt den für den Verbindungsaufbau zu verwendenden <see cref="IConfigurationProvider"/>
        /// </summary>
        public IConfigurationProvider ConfigurationProvider { get; }

        /// <summary>
        /// Die Anmelde-Informationen für einen nur lesenden Zugriff auf die Haupt-Datenbank
        /// </summary>
        public NetworkCredential ReadOnlyLogin { get; }

        /// <summary>
        /// Die NHibernate-<see cref="ISessionFactory"/> für einen nur lesenden Zugriff auf die Haupt-Datenbank
        /// </summary>
        public ISessionFactory ReadOnlySessionFactory { get; }

        /// <summary>
        /// Holt die Anmeldeinformationen des Superusers (<code>U0</code>)
        /// </summary>
        public NetworkCredential SuperUserLogin => _superUserLogin ?? (_superUserLogin = GetSuperUserLogin());

        /// <summary>
        /// Holt eine Abfrage für die Firmen aus der globalen Datenbank
        /// </summary>
        public IQueryable<GlobalPoco.Firma> Firmen => _session.Query<GlobalPoco.Firma>();

        /// <summary>
        /// Holt eine Abfrage für die angelegten Benutzer aus der globalen Datenbank
        /// </summary>
        public IQueryable<GlobalPoco.User> Users => _session.Query<GlobalPoco.User>();

        /// <summary>
        /// Erstellt eine <see cref="ISessionFactory"/> für eine Firmendatenbank
        /// </summary>
        /// <param name="company">Die Firma für die eine <see cref="ISessionFactory"/> zur Firmendatenbank aufgebaut werden soll</param>
        /// <param name="credential">Die für den Datenbankzugriff notwendigen Anmeldeinformationen</param>
        /// <returns>Die neue <see cref="ISessionFactory"/> für den Zugriff auf die Datenbank der <paramref name="company" /></returns>
        public ISessionFactory GetCompanySessionFactory([NotNull] GlobalPoco.Firma company, [NotNull] NetworkCredential credential)
        {
            return GetSessionFactoryFor(credential, company);
        }

        private NetworkCredential GetSuperUserLogin()
        {
            return _session.Get<GlobalPoco.User>(0).CreateCredential();
        }

        private ISessionFactory GetSessionFactoryFor([NotNull] NetworkCredential credential, [CanBeNull] GlobalPoco.Firma company)
        {
            if (credential.UserName == ReadOnlyLogin.UserName || company == null)
                return ReadOnlySessionFactory;
            var key = new SessionFactoryKey
            {
                DbName = company.Owner,
                UserName = credential.UserName,
            };
            var result = _userSessionFactory.GetOrAdd(key, _ => CreateSessionFactory(credential, company));
            return result;
        }

        private ISessionFactory CreateSessionFactory(NetworkCredential credential, GlobalPoco.Firma company)
        {
            var cfg = CreateConfiguration(credential, company);
            var sf = cfg.BuildSessionFactory();
            return sf;
        }

        private Configuration CreateConfiguration(NetworkCredential credential, GlobalPoco.Firma company)
        {
            var cfg = ConfigurationProvider.CreateConfiguration(credential, company);
            var userName = credential.UserName == ReadOnlyLogin.UserName ? "U0" : credential.UserName;
            var listener = new AuditEntityEventListener(userName);
            cfg.SetListener(ListenerType.PreUpdate, listener);
            cfg.SetListener(ListenerType.PreInsert, listener);
            foreach (var classMapping in cfg.ClassMappings)
            {
                classMapping.AddTuplizer(EntityMode.Poco, typeof(NullableTuplizer).AssemblyQualifiedName);
            }
            var fluentConfig = Fluently.Configure(cfg)
                .Mappings(m =>
                {
                    foreach (var mappingAssembly in ConfigurationProvider.MappingAssemblies)
                        m.FluentMappings.AddFromAssembly(mappingAssembly);
                })
                .BuildConfiguration();
            return fluentConfig;
        }

        private class SessionFactoryKey
        {
            public string UserName { get; set; }
            public string DbName { get; set; }
        }

        private class SessionFactoryKeyComparer : IComparer<SessionFactoryKey>, IEqualityComparer<SessionFactoryKey>
        {
            private readonly StringComparer _userNameComparer = StringComparer.OrdinalIgnoreCase;
            private readonly StringComparer _dbNameComparer = StringComparer.OrdinalIgnoreCase;

            public int Compare(SessionFactoryKey x, SessionFactoryKey y)
            {
                if (ReferenceEquals(x, y))
                    return 0;
                if (ReferenceEquals(x, null))
                    return -1;
                if (ReferenceEquals(y, null))
                    return 1;
                var v = _userNameComparer.Compare(x.UserName, y.UserName);
                if (v != 0)
                    return v;
                return _dbNameComparer.Compare(x.DbName, y.DbName);
            }

            public bool Equals(SessionFactoryKey x, SessionFactoryKey y)
            {
                return Compare(x, y) == 0;
            }

            public int GetHashCode(SessionFactoryKey obj)
            {
                return _userNameComparer.GetHashCode(obj.UserName)
                       ^ _dbNameComparer.GetHashCode(obj.DbName);
            }
        }
    }
}
