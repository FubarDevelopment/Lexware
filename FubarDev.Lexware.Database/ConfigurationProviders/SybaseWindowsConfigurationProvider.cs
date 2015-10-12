//-----------------------------------------------------------------------
// <copyright file="SybaseWindowsConfigurationProvider.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Net;
using System.Reflection;

using FubarDev.Lexware.Database.Global;

using JetBrains.Annotations;

using NHibernate.Cfg;

namespace FubarDev.Lexware.Database.ConfigurationProviders
{
    /// <summary>
    /// Eine <see cref="IConfigurationProvider"/>-Implementation, die die Sybase ASA ADO.NET-Treiber
    /// verwendet um eine Verbindung zu der Lexware-Datenbank aufzubauen.
    /// </summary>
    public class SybaseWindowsConfigurationProvider : IConfigurationProvider
    {
        /// <summary>
        /// Der Standard-Datenbank-Server-Pfad
        /// </summary>
        public const string DefaultServerDatabasePath = @"c:\ProgramData\Lexware\professional\Datenbank";

        private static readonly string DefaultDatabase = "LXOFFICE";

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="SybaseWindowsConfigurationProvider"/> Klasse.
        /// </summary>
        /// <param name="hostName">Der Name, bzw. die IP des Datenbank-Servers</param>
        /// <remarks>Als Server-Datenbank-Pfad wird der Wert aus <see cref="DefaultServerDatabasePath"/> verwendet.</remarks>
        public SybaseWindowsConfigurationProvider([NotNull] string hostName)
            : this(hostName, DefaultServerDatabasePath)
        {
        }

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="SybaseWindowsConfigurationProvider"/> Klasse.
        /// </summary>
        /// <param name="hostName">Der Name, bzw. die IP des Datenbank-Servers</param>
        /// <param name="globalDatabasePath">Der Datenbank-Pfad auf dem Server</param>
        public SybaseWindowsConfigurationProvider([NotNull] string hostName, [NotNull] string globalDatabasePath)
        {
            HostName = hostName;
            GlobalDatabasePath = globalDatabasePath;
            MappingAssemblies.Add(typeof(Global.Mappings.FirmaMap).Assembly);
        }

        /// <summary>
        /// Holt den Server-Namen, bzw. die Server-Adresse
        /// </summary>
        public string HostName { get; }

        /// <summary>
        /// Holt den Datenbank-Pfad auf dem Server
        /// </summary>
        public string GlobalDatabasePath { get; }

        /// <inheritdoc/>
        public List<Assembly> MappingAssemblies { get; } = new List<Assembly>();

        /// <inheritdoc/>
        public virtual string GetConnectionString(NetworkCredential credential, Firma company)
        {
            var csb = new DbConnectionStringBuilder()
            {
                BrowsableConnectionString = true,
            };
            csb.Add("UserID", credential.UserName);
            csb.Add("Password", credential.Password);
            csb.Add("DatabaseName", company?.Owner ?? DefaultDatabase);
            csb.Add("DatabaseFile", GetDatabasePath(company));
            csb.Add("ServerName", "lxdbsrv");
            csb.Add("CommLinks", $"TCPIP(Host={HostName})");
            return csb.ConnectionString;
        }

        /// <inheritdoc/>
        public virtual Configuration CreateConfiguration(NetworkCredential credential, Firma company)
        {
            var cfg = new Configuration();
            cfg.SetProperties(new Dictionary<string, string>
            {
                { Environment.ConnectionString, GetConnectionString(credential, company) },
                { Environment.Dialect, typeof(NHibernate.Dialect.SybaseSQLAnywhere12Dialect).AssemblyQualifiedName },
                { Environment.ConnectionDriver, typeof(NHibernate.Driver.SybaseSQLAnywhereDotNet4Driver).AssemblyQualifiedName },
            });
            foreach (var mappingAssembly in MappingAssemblies)
            {
                cfg.AddAssembly(mappingAssembly);
            }
            return cfg;
        }

        /// <summary>
        /// Ermittlung des Server-Datenbank-Pfades
        /// </summary>
        /// <param name="company">Die Firma für die der Datenbank-Pfad ermittelt werden soll (kann <code>null</code> sein)</param>
        /// <returns>Der Server-Datenbank-Pfad</returns>
        protected virtual string GetDatabasePath([CanBeNull] Firma company)
        {
            if (company == null)
                return Path.Combine(GlobalDatabasePath, "LXOffice.db");
            return Path.Combine(GlobalDatabasePath, company.Path, "LxCompany.db");
        }
    }
}
