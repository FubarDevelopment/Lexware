//-----------------------------------------------------------------------
// <copyright file="PreisArt.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using System.ComponentModel;

namespace FubarDev.Lexware.Database.Faktura
{
    /// <summary>
    /// Verwendeter Preis
    /// </summary>
    public enum PreisArt
    {
        /// <summary>
        /// Preis aus den Stammdaten
        /// </summary>
        Stammdatenpreis,

        /// <summary>
        /// Manuell eingetragener Preis
        /// </summary>
        Manuell,

        /// <summary>
        /// Preis aus einer Aktion
        /// </summary>
        Aktionspreis,

        /// <summary>
        /// Preis speziell für einen Kunden?
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        Kundenpreis,
    }
}