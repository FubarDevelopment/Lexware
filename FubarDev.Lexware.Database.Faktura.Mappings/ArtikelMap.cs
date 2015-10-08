//-----------------------------------------------------------------------
// <copyright file="ArtikelMap.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using FluentNHibernate.Mapping;

namespace FubarDev.Lexware.Database.Faktura.Mappings
{
    public class ArtikelMap : ClassMap<Artikel>
    {
        public ArtikelMap()
        {
            Table("FK_Artikel");

            Id(m => m.SheetNr).GeneratedBy.Custom<NhSupport.LexwareIdTableGenerator>(p =>
            {
                p.AddParam(NhSupport.LexwareIdTableGenerator.TargetTableNameParam, "FK_Artikel")
                    .AddParam(NhSupport.LexwareIdTableGenerator.TargetTableIdColumnNameParam, "SheetNr");
            });

            NaturalId()
                .Property(x => x.ArtikelNr);

            Map(m => m.Bezeichnung);
            Map(m => m.Beschreibung).CustomType("StringClob");

            Map(m => m.Created, "System_created");
            Map(m => m.CreatedBy, "System_created_user");
            Map(m => m.Updated, "System_updated");
            Map(m => m.UpdatedBy, "System_updated_user");
        }
    }
}
