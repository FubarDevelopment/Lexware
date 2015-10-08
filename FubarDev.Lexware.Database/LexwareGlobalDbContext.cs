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
    public sealed class LexwareGlobalDbContext
    {
        private readonly ConcurrentDictionary<SessionFactoryKey, ISessionFactory> _userSessionFactory = new ConcurrentDictionary<SessionFactoryKey, ISessionFactory>(new SessionFactoryKeyComparer());

        private readonly IStatelessSession _session;

        private NetworkCredential _superUserLogin;

        public LexwareGlobalDbContext(IConfigurationProvider configurationProvider)
        {
            ConfigurationProvider = configurationProvider;
            ReadOnlyLogin = new NetworkCredential("_login_", "92ab346d1c02cffc");
            ReadOnlySessionFactory = CreateSessionFactory(ReadOnlyLogin, null);
            _session = ReadOnlySessionFactory.OpenStatelessSession();
        }

        public IConfigurationProvider ConfigurationProvider { get; }

        public NetworkCredential ReadOnlyLogin { get; }

        public ISessionFactory ReadOnlySessionFactory { get; }

        public NetworkCredential SuperUserLogin => _superUserLogin ?? (_superUserLogin = GetSuperUserLogin());

        public IQueryable<GlobalPoco.Firma> Firmen => _session.Query<GlobalPoco.Firma>();

        public IQueryable<GlobalPoco.User> Users => _session.Query<GlobalPoco.User>();

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
