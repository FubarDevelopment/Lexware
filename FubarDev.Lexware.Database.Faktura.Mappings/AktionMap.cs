//-----------------------------------------------------------------------
// <copyright file="AktionMap.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using FluentNHibernate.Mapping;

using FubarDev.Lexware.Database.NhSupport;

namespace FubarDev.Lexware.Database.Faktura.Mappings
{
    public class AktionMap : ClassMap<Aktion>
    {
        public AktionMap()
        {
            Table("FK_Aktion");

            Id(m => m.Id, "lID").GeneratedBy.Custom<LexwareIdTableGenerator>(p =>
            {
                p.AddParam(LexwareIdTableGenerator.TargetTableNameParam, "FK_Aktion")
                    .AddParam(LexwareIdTableGenerator.TargetTableIdColumnNameParam, "lID");
            });

            Map(m => m.Beginn, "datBegin").CustomType<LocalDateType>();
            Map(m => m.Ende, "datEnde").CustomType<LocalDateType>();
            Map(m => m.Kurzbezeichnung, "szKurz");
            Map(m => m.Bezeichnung, "szBezeichnung");
            Map(m => m.Beschreibung, "szBeschreibung");
            Map(m => m.Gesperrt, "fGesperrt");
            Map(m => m.Allgemein, "fAllgemein");
            Map(m => m.Auftragsdruck, "fAuftragsdruck");
        }
    }
}
