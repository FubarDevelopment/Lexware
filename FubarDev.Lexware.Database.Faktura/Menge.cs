//-----------------------------------------------------------------------
// <copyright file="Menge.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using System;
using System.Diagnostics.CodeAnalysis;

using FubarDev.Lexware.Database.Shared;

namespace FubarDev.Lexware.Database.Faktura
{
    public class Menge : IAuditEntity, IEquatable<Menge>
    {
        /// <summary>
        /// MengenNr
        /// </summary>
        public virtual int Nummer { get; set; }

        /// <summary>
        /// ArtikelNr
        /// </summary>
        public virtual string ArtikelNr { get; set; }

        /// <summary>
        /// Menge
        /// </summary>
        public virtual decimal Anzahl { get; set; }

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

        /// <inheritdoc/>
        public virtual bool Equals(Menge other)
        {
            if (ReferenceEquals(other, null))
                return false;
            return Nummer == other.Nummer
                   && (ArtikelNr ?? string.Empty).Equals(other.ArtikelNr ?? string.Empty, StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return Equals((Menge)obj);
        }

        /// <inheritdoc/>
        [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode", Justification = "Die Werte müssen durch den O/R-Mapper gefüllt werden können.")]
        public override int GetHashCode()
        {
            return Nummer.GetHashCode()
                ^ (ArtikelNr ?? string.Empty).GetHashCode();
        }
    }
}
