//-----------------------------------------------------------------------
// <copyright file="PreisgruppeMap.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using FluentNHibernate.Mapping;

namespace FubarDev.Lexware.Database.Faktura.Mappings
{
    public class PreisgruppeMap : ClassMap<Preisgruppe>
    {
        public PreisgruppeMap()
        {
            Table("FK_Preisgruppe");

            Id(m => m.Id, "PreisgrpNr").GeneratedBy.Custom<NhSupport.LexwareIdTableGenerator>(p =>
            {
                p.AddParam(NhSupport.LexwareIdTableGenerator.TargetTableNameParam, "FK_Preisgruppe")
                    .AddParam(NhSupport.LexwareIdTableGenerator.TargetTableIdColumnNameParam, "PreisgrpNr");
            });

            Map(m => m.Name, "Preisgrp").Length(20);

            Map(m => m.Created, "System_created");
            Map(m => m.CreatedBy, "System_created_user");
            Map(m => m.Updated, "System_updated");
            Map(m => m.UpdatedBy, "System_updated_user");
        }
    }
}
