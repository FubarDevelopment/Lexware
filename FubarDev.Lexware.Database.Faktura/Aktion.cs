//-----------------------------------------------------------------------
// <copyright file="Aktion.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using NodaTime;

namespace FubarDev.Lexware.Database.Faktura
{
    public class Aktion
    {
        /// <summary>
        /// lID
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// datBegin
        /// </summary>
        public virtual LocalDate Beginn { get; set; }

        /// <summary>
        /// datEnde
        /// </summary>
        public virtual LocalDate Ende { get; set; }

        /// <summary>
        /// szKurz
        /// </summary>
        public virtual string Kurzbezeichnung { get; set; }

        /// <summary>
        /// szBezeichnung
        /// </summary>
        public virtual string Bezeichnung { get; set; }

        /// <summary>
        /// szBeschreibung
        /// </summary>
        public virtual string Beschreibung { get; set; }

        /// <summary>
        /// fGesperrt
        /// </summary>
        public virtual bool Gesperrt { get; set; }

        /// <summary>
        /// fAllgemein
        /// </summary>
        public virtual bool Allgemein { get; set; }

        /// <summary>
        /// fAuftragsdruck
        /// </summary>
        public virtual bool Auftragsdruck { get; set; }
    }
}
