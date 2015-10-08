using System;
using System.Collections.Generic;
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

        public virtual bool Equals(Menge other)
        {
            if (ReferenceEquals(other, null))
                return false;
            return Nummer == other.Nummer
                   && (ArtikelNr ?? string.Empty).Equals(other.ArtikelNr ?? string.Empty, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            return Equals((Menge)obj);
        }

        [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")]
        public override int GetHashCode()
        {
            return Nummer.GetHashCode()
                ^ (ArtikelNr ?? string.Empty).GetHashCode();
        }
    }
}
