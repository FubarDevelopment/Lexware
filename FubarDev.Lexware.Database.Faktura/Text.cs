// <copyright file="Text.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

using FubarDev.Lexware.Database.Shared;

namespace FubarDev.Lexware.Database.Faktura
{
    /// <summary>
    /// Lange Texte auf die Verwiesen werden kann
    /// </summary>
    public class Text : IZeroAsNullEntity
    {
        /// <summary>
        /// Holt oder setzt die Identifikationsnummer
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// Holt oder setzt den Text-Typ
        /// </summary>
        public virtual int? Typ { get; set; }

        /// <summary>
        /// Holt oder setzt die Kennung
        /// </summary>
        public virtual int? Kennung { get; set; }

        /// <summary>
        /// Holt oder setzt den eigentlichen Text
        /// </summary>
        public virtual string Wert { get; set; }
    }
}
