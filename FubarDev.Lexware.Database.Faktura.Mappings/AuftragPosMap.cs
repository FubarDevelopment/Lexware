//-----------------------------------------------------------------------
// <copyright file="AuftragPosMap.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using FluentNHibernate.Mapping;

using FubarDev.Lexware.Database.NhSupport;

namespace FubarDev.Lexware.Database.Faktura.Mappings
{
    /// <summary>
    /// NHibernate-Mapping für <see cref="AuftragPos"/>
    /// </summary>
    public class AuftragPosMap : ClassMap<AuftragPos>
    {
        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="AboVorlagePosMap"/> Klasse.
        /// </summary>
        public AuftragPosMap()
        {
            Table("FK_AuftragPos");

            Id(m => m.Id, "LNr").GeneratedBy.Custom<LexwareIdTableGenerator>(p =>
            {
                p.AddParam(LexwareIdTableGenerator.TargetTableNameParam, "FK_AuftragPos")
                    .AddParam(LexwareIdTableGenerator.TargetTableIdColumnNameParam, "LNr");
            });

            NaturalId()
                .Property(m => m.AuftragsNr)
                .Property(m => m.Auftragskennung, "AuftragsKennung")
                .Property(m => m.LfdNr);

            Map(m => m.PosNr);
            Map(m => m.PosText);
            Map(m => m.ArtikelNr);
            References(m => m.ArtikelVonId, "lArtikelID").LazyLoad(Laziness.Proxy);
            Map(m => m.ArtikelBezeichnung, "Artikel_Bezeichnung");
            Map(m => m.ArtikelKurzbezeichnung, "szArtikel_Kurzbezeichnung");
            Map(m => m.ArtikelMenge, "Artikel_Menge");
            Map(m => m.ArtikelPreisfaktor, "Artikel_Preisfaktor");
            Map(m => m.SummenPreis, "Summen_preis");
            Map(m => m.SummenRabatt, "Summen_rabatt");
            Map(m => m.SummenRabattProzent, "Summen_rabatt_proz");
            Map(m => m.SummenNetto, "Summen_netto");
            Map(m => m.SummenBrutto, "Summen_brutto");
            Map(m => m.SummenUmsatzsteuerProzent, "Summen_ust_proz");
            Map(m => m.SummenUmsatzsteuerGesamt, "Summen_ust_gesamt");
            Map(m => m.SummenUmsatzsteuerNachAuftragsrabatt, "Summen_ust_nach_Aufrab");
            Map(m => m.SummenNettoNachAuftragsrabatt, "Summen_netto_nach_Aufrab");
            Map(m => m.SummenBruttoNachAuftragsrabatt, "Summen_brutto_nach_Aufrab");
            Map(m => m.MitAuftragsrabatt, "bMitAuftragsrabatt");
            Map(m => m.ArtikelpreisNetto, "dftArtikelpreisNetto");
            Map(m => m.ArtikelpreisBrutto, "dftArtikelpreisBrutto");
            Map(m => m.PreisManuell, "fPreisManuell");
            Map(m => m.PreisArt, "lPreisArt").Not.Nullable().CustomType<GenericPersistentEnumType<PreisArt>>();
            References(r => r.Preis, "lPreisID").LazyLoad(Laziness.Proxy).ForeignKey("none");

            Map(m => m.Created, "System_created");
            Map(m => m.CreatedBy, "System_created_user");
            Map(m => m.Updated, "System_updated");
            Map(m => m.UpdatedBy, "System_updated_user");
        }
    }
}
