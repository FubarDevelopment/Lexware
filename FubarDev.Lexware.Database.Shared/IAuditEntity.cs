//-----------------------------------------------------------------------
// <copyright file="IAuditEntity.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using System;

namespace FubarDev.Lexware.Database.Shared
{
    /// <summary>
    /// Schnittstelle für eine Entität mit Audit-Feldern
    /// </summary>
    public interface IAuditEntity
    {
        /// <summary>
        /// Holt oder setzt die Information wann der Datensatz erstellt wurde
        /// </summary>
        DateTime? Created { get; set; }

        /// <summary>
        /// Holt oder setzt die Information von wem dieser Datensatz erstellt wurde
        /// </summary>
        string CreatedBy { get; set; }

        /// <summary>
        /// Holt oder setzt die Information wann der Datensatz aktualisiert wurde
        /// </summary>
        DateTime? Updated { get; set; }

        /// <summary>
        /// Holt oder setzt die Information von wem dieser Datensatz aktualisiert wurde
        /// </summary>
        string UpdatedBy { get; set; }
    }
}
