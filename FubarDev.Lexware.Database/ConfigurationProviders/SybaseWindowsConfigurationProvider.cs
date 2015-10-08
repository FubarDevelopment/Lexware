using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Net;
using System.Reflection;

using FluentNHibernate;
using FluentNHibernate.Cfg;

using FubarDev.Lexware.Database.Global;

using JetBrains.Annotations;

using NHibernate.Cfg;

namespace FubarDev.Lexware.Database.ConfigurationProviders
{
    public class SybaseWindowsConfigurationProvider : IConfigurationProvider
    {
        public const string DefaultServerDatabasePath = @"c:\ProgramData\Lexware\professional\Datenbank";

        private static readonly string DefaultDatabase = "LXOFFICE";

        public SybaseWindowsConfigurationProvider([NotNull] string hostName)
            : this(hostName, DefaultServerDatabasePath)
        {
        }

        public SybaseWindowsConfigurationProvider([NotNull] string hostName, [NotNull] string globalDatabasePath)
        {
            HostName = hostName;
            GlobalDatabasePath = globalDatabasePath;
            MappingAssemblies.Add(typeof(Global.Mappings.FirmaMap).Assembly);
        }

        public string HostName { get; }

        public string GlobalDatabasePath { get; }

        public List<Assembly> MappingAssemblies { get; } = new List<Assembly>();

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
            //var fluentConfig = Fluently.Configure(cfg)
            //    .BuildConfiguration();
            return cfg;
        }

        protected virtual string GetDatabasePath([CanBeNull] Firma company)
        {
            if (company == null)
                return Path.Combine(GlobalDatabasePath, "LXOffice.db");
            return Path.Combine(GlobalDatabasePath, company.Path, "LxCompany.db");
        }
    }
}
