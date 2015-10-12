//-----------------------------------------------------------------------
// <copyright file="Preisgruppe.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using System;

using FubarDev.Lexware.Database.Shared;

namespace FubarDev.Lexware.Database.Faktura
{
    /// <summary>
    /// Benannte Preisgruppe (<code>FK_Preisgruppe</code>)
    /// </summary>
    public class Preisgruppe : IAuditEntity
    {
        /// <summary>
        /// PreisgrpNr
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Preisgrp
        /// </summary>
        public virtual string Name { get; set; }

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
