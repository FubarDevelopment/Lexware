// <copyright file="Artikel.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

using System;

using FubarDev.Lexware.Database.Shared;

namespace FubarDev.Lexware.Database.Faktura
{
    /// <summary>
    /// Stammdaten für Artikel
    /// </summary>
    public class Artikel : IAuditEntity
    {
        /// <summary>
        /// ID (<code>SheetNr</code>)
        /// </summary>
        public virtual int SheetNr { get; set; }

        /// <summary>
        /// Artikel-Nummer (<code>ArtikelNr</code>)
        /// </summary>
        public virtual string ArtikelNr { get; set; }

        /// <summary>
        /// Artikel-Bezeichnung (<code>Bezeichnung</code>)
        /// </summary>
        public virtual string Bezeichnung { get; set; }

        /// <summary>
        /// Artikel-Beschreibung (<code>StringClob</code>)
        /// </summary>
        public virtual string Beschreibung { get; set; }

        /// <summary>
        /// System_created
        /// </summary>
        public virtual DateTime? Created { get; set; }

        /// <summary>
        /// System_created_user
        /// </summary>
        public virtual string CreatedBy { get; set; }

        /// <summary>
        /// System_updated
        /// </summary>
        public virtual DateTime? Updated { get; set; }

        /// <summary>
        /// System_updated_user
        /// </summary>
        public virtual string UpdatedBy { get; set; }
    }
}
