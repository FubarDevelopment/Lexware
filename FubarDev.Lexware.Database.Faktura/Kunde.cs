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
    /// <summary>
    /// Kundenstammdaten (<code>FK_Kunde</code>)
    /// </summary>
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
        /// Holt oder setzt einen Status für irgendetwas, was mit dem BDSG (Bundesdatenschutzgesetz) zu tun hat.
        /// </summary>
        public virtual int? BDSGStatus { get; set; }

        /// <summary>
        /// Holt oder setzt einen Text für irgendetwas, was mit dem BDSG (Bundesdatenschutzgesetz) zu tun hat.
        /// </summary>
        public virtual Text BDSGText { get; set; }

        /// <summary>
        /// Holt oder setzt einen Zeitstempel für irgendetwas, was mit dem BDSG (Bundesdatenschutzgesetz) zu tun hat.
        /// </summary>
        public virtual DateTime? BDSGZeitpunkt { get; set; }

        /// <summary>
        /// szUserdefined1
        /// </summary>
        public virtual string UserDefined1 { get; set; }

        /// <summary>
        /// szUserdefined2
        /// </summary>
        public virtual string UserDefined2 { get; set; }

        /// <summary>
        /// szUserdefined3
        /// </summary>
        public virtual string UserDefined3 { get; set; }

        /// <summary>
        /// szUserdefined4
        /// </summary>
        public virtual string UserDefined4 { get; set; }

        /// <summary>
        /// szUserdefined5
        /// </summary>
        public virtual string UserDefined5 { get; set; }

        /// <summary>
        /// szUserdefined6
        /// </summary>
        public virtual string UserDefined6 { get; set; }

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
