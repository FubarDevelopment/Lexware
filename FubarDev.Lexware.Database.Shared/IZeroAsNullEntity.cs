//-----------------------------------------------------------------------
// <copyright file="IZeroAsNullEntity.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

namespace FubarDev.Lexware.Database.Shared
{
    /// <summary>
    /// Verweise auf diese Entität verwenden eine Null (<code>0</code>) als nicht-vorhandenen
    /// Verweis im Gegensatz zu dem sonst üblichen <code>NULL</code>-Wert.
    /// </summary>
    public interface IZeroAsNullEntity
    {
        /// <summary>
        /// Holt oder setzt die ID des Datensatzes
        /// </summary>
        int Id { get; set; }
    }
}
