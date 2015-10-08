//-----------------------------------------------------------------------
// <copyright file="Preis.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using FubarDev.Lexware.Database.Shared;

namespace FubarDev.Lexware.Database.Faktura
{
    public class Preis : IZeroAsNullEntity
    {
        /// <summary>
        /// lID
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// lArtikelID
        /// </summary>
        public virtual Artikel Artikel { get; set; }

        /// <summary>
        /// lAktionsID
        /// </summary>
        public virtual Aktion Aktion { get; set; }

        /// <summary>
        /// dftVK
        /// </summary>
        public virtual decimal Verkaufspreis { get; set; }

        /// <summary>
        /// szBemerkung
        /// </summary>
        public virtual string Bemerkung { get; set; }

        /// <summary>
        /// fGesperrt
        /// </summary>
        public virtual bool Gesperrt { get; set; }

        /// <summary>
        /// fRabattfaehig
        /// </summary>
        public virtual bool Rabattfaehig { get; set; }
    }
}