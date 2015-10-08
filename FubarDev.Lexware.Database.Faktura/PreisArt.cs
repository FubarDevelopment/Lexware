//-----------------------------------------------------------------------
// <copyright file="PreisArt.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using System.ComponentModel;

namespace FubarDev.Lexware.Database.Faktura
{
    public enum PreisArt
    {
        Stammdatenpreis,
        Manuell,
        Aktionspreis,

        [EditorBrowsable(EditorBrowsableState.Never)]
        Kundenpreis,
    }
}