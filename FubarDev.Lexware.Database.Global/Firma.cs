using System;

using FubarDev.Lexware.Database.Shared;

namespace FubarDev.Lexware.Database.Global
{
    public class Firma : IAuditEntity
    {
        /// <summary>
        /// lID_Firma
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// szName
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// szOwner
        /// </summary>
        public virtual string Owner { get; set; }

        /// <summary>
        /// szPath
        /// </summary>
        public virtual string Path { get; set; }

        /// <summary>
        /// datErstelltAm
        /// </summary>
        public virtual DateTime? Created { get; set; }

        /// <summary>
        /// szUserErstelltAm
        /// </summary>
        public virtual string CreatedBy { get; set; }

        /// <summary>
        /// datGeaendertAm
        /// </summary>
        public virtual DateTime? Updated { get; set; }

        /// <summary>
        /// szUserGeaendertAm
        /// </summary>
        public virtual string UpdatedBy { get; set; }
    }
}
