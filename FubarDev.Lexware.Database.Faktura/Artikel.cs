using System;

using FubarDev.Lexware.Database.Shared;

namespace FubarDev.Lexware.Database.Faktura
{
    public class Artikel : IAuditEntity
    {
        public virtual int SheetNr { get; set; }
        public virtual string ArtikelNr { get; set; }
        public virtual string Bezeichnung { get; set; }
        public virtual string Beschreibung { get; set; }

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
