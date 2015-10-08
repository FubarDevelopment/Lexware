//-----------------------------------------------------------------------
// <copyright file="Kunde.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using System;

using FubarDev.Lexware.Database.Shared;

namespace FubarDev.Lexware.Database.Faktura
{
    public class Kunde : IAuditEntity
    {
        /// <summary>
        /// SheetNr
        /// </summary>
        public virtual int SheetNr { get; set; }

        /// <summary>
        /// KundenNr
        /// </summary>
        public virtual string KundenNr { get; set; }

        /// <summary>
        /// Anschrift_Anrede, Anschrift_Firma, Anschrift_Ort, Anschrift_Plz
        /// </summary>
        public virtual Adresse Anschrift { get; set; }

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
