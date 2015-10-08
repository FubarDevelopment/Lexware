//-----------------------------------------------------------------------
// <copyright file="FirmaMap.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using FluentNHibernate.Mapping;

namespace FubarDev.Lexware.Database.Global.Mappings
{
    /// <summary>
    /// Das Mapping für die Lexware-Firma
    /// </summary>
    public class FirmaMap : ClassMap<Firma>
    {
        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="FirmaMap"/> Klasse.
        /// </summary>
        public FirmaMap()
        {
            Schema("LEXGLOBAL");
            Table("LXG_FIRMA");
            Id(x => x.Id, "lID_Firma");
            Map(x => x.Name, "szName").Not.Nullable();
            Map(x => x.Owner, "szOwner").Not.Nullable();
            Map(x => x.Path, "szPath").Not.Nullable();

            Map(m => m.Created, "datErstelltAm");
            Map(m => m.CreatedBy, "szUserErstelltAm");
            Map(m => m.Updated, "datGeaendertAm");
            Map(m => m.UpdatedBy, "szUserGeaendertAm");
        }
    }
}
