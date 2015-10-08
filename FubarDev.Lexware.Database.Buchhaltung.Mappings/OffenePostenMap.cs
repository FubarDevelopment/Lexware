//-----------------------------------------------------------------------
// <copyright file="OffenePostenMap.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using FluentNHibernate.Conventions.Helpers;
using FluentNHibernate.Mapping;

using FubarDev.Lexware.Database.NhSupport;

namespace FubarDev.Lexware.Database.Buchhaltung.Mappings
{
    public class OffenePostenMap : ClassMap<OffenePosten>
    {
        public OffenePostenMap()
        {
            Table("BH_OFFENEPOSTEN");

            Id(m => m.Id, "lNr").GeneratedBy.Custom<LexwareIdTableGenerator>(p =>
            {
                p.AddParam(LexwareIdTableGenerator.TargetTableNameParam, "BH_OFFENEPOSTEN")
                    .AddParam(LexwareIdTableGenerator.TargetTableIdColumnNameParam, "lNr");
            });

            ConventionBuilder.Property.When(c => c.Expect(e => e.Type.Name == "System.Int32"), x => x.Column("l" + x.Name));

            Map(p => p.BuchungsNr, "lBuchungsNr");
            Map(p => p.Jahr, "lJahr");
            Map(p => p.Belegdatum, "datBeleg").CustomType<LocalDateType>();
            Map(p => p.Konto, "lKonto");
            Map(p => p.Kennung, "lKennung");
            Map(p => p.Mahnstufe, "lMahnstufe");
            Map(p => p.Zahlung, "lZahlung");
            Map(p => p.Betrag, "dftBetrag");
            Map(p => p.Rest, "dftRest");
            Map(p => p.WaehrungId, "lWaehrung");
            Map(p => p.Belegkreis, "lBelegKreis");
            Map(p => p.Belegnummer, "szBelegNr").Nullable().Length(20);
            Map(p => p.ZahlungszielSkonto, "lZahlungszielSkonto");
            Map(p => p.SkontoProzent, "dftSkonto");
            Map(p => p.Mahnungsdatum1, "datMahnung1").CustomType<LocalDateType>();
            Map(p => p.Mahnungsdatum2, "datMahnung2").CustomType<LocalDateType>();
            Map(p => p.Mahnungsdatum3, "datMahnung3").CustomType<LocalDateType>();
            Map(p => p.Mahnungsdatum4, "datMahnung4").CustomType<LocalDateType>();
            Map(p => p.KundenLiefNr, "szKundenLiefNr").Not.Nullable().Length(20);
            Map(p => p.Mahnen, "bMahnen");
            Map(p => p.Matchcode, "szMatchcode").Nullable().Length(80);
            Map(p => p.ErledigtStatus, "lErledigtStatus");
            Map(p => p.ProgId, "szProgId");
            Map(p => p.DruckFolge, "lDruckFolge");
            Map(p => p.Gedruckt, "datGedruckt").CustomType<LocalDateType>();
            Map(p => p.Mahnung1, "lMahnung1");
            Map(p => p.Mahnung2, "lMahnung2");
            Map(p => p.Mahnung3, "lMahnung3");
            Map(p => p.BetragDM, "dftBetragDM");
            Map(p => p.RestDM, "dftRestDM");
            Map(p => p.BetragEUR, "dftBetragEUR");
            Map(p => p.RestEUR, "dftRestEUR");
            Map(p => p.Stapel, "bStapel");
            Map(p => p.Mahngebuehr, "dftMahngebuehr");
            Map(p => p.Zinssatz, "dftZinssatz");
            Map(p => p.Zinsen, "dftZinsen");
            Map(p => p.AuftragsNr, "szAuftragsNr").Length(20);
            Map(p => p.Auftragskennung, "lAuftragsKennung");
            Map(p => p.Faelligkeitsdatum, "datFaellig").CustomType<LocalDateType>();
            Map(p => p.SkontoDatum, "datSkonto").CustomType<LocalDateType>();
            Map(p => p.ZahlungszielSkonto2, "lZahlungszielSkonto2");
            Map(p => p.SkontoProzent2, "dftSkonto2");
            Map(p => p.WarenwirtschaftZahlung, "dftWawiZahlung");
            Map(p => p.Rueckgesetzt, "bRueckgesetzt");
            Map(p => p.FixFaellig, "bFixFaellig");
            Map(p => p.TagVonMonat, "lTagVonMonat");
            Map(p => p.TageVorlauf, "lTageVorlauf");
        }
    }
}
