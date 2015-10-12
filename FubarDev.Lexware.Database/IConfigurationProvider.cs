//-----------------------------------------------------------------------
// <copyright file="IConfigurationProvider.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using System.Collections.Generic;
using System.Net;
using System.Reflection;

using FubarDev.Lexware.Database.Global;

using JetBrains.Annotations;

using NHibernate.Cfg;

namespace FubarDev.Lexware.Database
{
    /// <summary>
    /// Der Konfigurationsanbieter mithilfe dessen der <see cref="LexwareGlobalDbContext"/> die Verbindung zum Lexware-Datenbank-Server
    /// aufbaut.
    /// </summary>
    public interface IConfigurationProvider
    {
        /// <summary>
        /// Holt die Assemblies die auf Fluent NHibernate-Mappings überprüft werden sollen.
        /// </summary>
        List<Assembly> MappingAssemblies { get; }

        /// <summary>
        /// Erstellt eine Verbindungszeichenfolge für den Aufbau einer Datenbank-Verbindung über den ADO.NET-Treiber
        /// </summary>
        /// <param name="credential">Die zu verwendenden Anmeldeinformationen</param>
        /// <param name="company">Die Datenbank der Firma zu der verbinden werden soll</param>
        /// <returns>Die neue Verbindungszeichenfolge</returns>
        string GetConnectionString([NotNull] NetworkCredential credential, [CanBeNull] Firma company);

        /// <summary>
        /// Erstellt eine NHibernate-Konfiguration
        /// </summary>
        /// <param name="credential">Die zu verwendenden Anmeldeinformationen</param>
        /// <param name="company">Die Datenbank der Firma zu der verbinden werden soll</param>
        /// <returns>Die neue NHibernate-Konfiguration</returns>
        Configuration CreateConfiguration([NotNull] NetworkCredential credential, [CanBeNull] Firma company);
    }
}
