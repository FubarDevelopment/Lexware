//-----------------------------------------------------------------------
// <copyright file="KundeMap.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using FluentNHibernate.Mapping;

namespace FubarDev.Lexware.Database.Faktura.Mappings
{
    public class KundeMap : ClassMap<Kunde>
    {
        public KundeMap()
        {
            Table("FK_Kunde");

            Id(m => m.SheetNr).GeneratedBy.Custom<NhSupport.LexwareIdTableGenerator>(p =>
            {
                p.AddParam(NhSupport.LexwareIdTableGenerator.TargetTableNameParam, "FK_Kunde")
                    .AddParam(NhSupport.LexwareIdTableGenerator.TargetTableIdColumnNameParam, "SheetNr");
            });

            NaturalId()
                .Property(x => x.KundenNr);

            Component(x => x.Anschrift, c =>
            {
                c.ColumnPrefix("Anschrift_");
                c.Map(p => p.Firma);
                c.Map(p => p.Anrede);
                c.Map(p => p.Plz);
                c.Map(p => p.Ort);
            });

            Map(m => m.Created, "System_created");
            Map(m => m.CreatedBy, "System_created_user");
            Map(m => m.Updated, "System_updated");
            Map(m => m.UpdatedBy, "System_updated_user");
        }
    }
}
