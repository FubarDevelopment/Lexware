//-----------------------------------------------------------------------
// <copyright file="OffenePosten.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using NodaTime;

namespace FubarDev.Lexware.Database.Buchhaltung
{
    /// <summary>
    /// Offene Posten (<code>BH_OFFENEPOSTEN</code>)
    /// </summary>
    public class OffenePosten
    {
        /// <summary>
        /// lNr
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// lBuchungsNr
        /// </summary>
        public virtual int BuchungsNr { get; set; }

        /// <summary>
        /// lJahr
        /// </summary>
        public virtual int? Jahr { get; set; }

        /// <summary>
        /// datBeleg
        /// </summary>
        public virtual LocalDate Belegdatum { get; set; }

        /// <summary>
        /// lKonto
        /// </summary>
        public virtual int Konto { get; set; }

        /// <summary>
        /// lKennung
        /// </summary>
        public virtual int Kennung { get; set; }

        /// <summary>
        /// lMahnstufe
        /// </summary>
        public virtual int Mahnstufe { get; set; }

        /// <summary>
        /// lZahlung
        /// </summary>
        public virtual int Zahlung { get; set; }

        /// <summary>
        /// dftBetrag
        /// </summary>
        public virtual decimal Betrag { get; set; }

        /// <summary>
        /// dftRest
        /// </summary>
        public virtual decimal Rest { get; set; }

        /// <summary>
        /// lWaehrung
        /// </summary>
        public virtual int WaehrungId { get; set; }

        /// <summary>
        /// lBelegKreis
        /// </summary>
        public virtual int Belegkreis { get; set; }

        /// <summary>
        /// szBelegNr(20)
        /// </summary>
        public virtual string Belegnummer { get; set; }

        /// <summary>
        /// lZahlungszielSkonto
        /// </summary>
        public virtual int ZahlungszielSkonto { get; set; }

        /// <summary>
        /// dftSkonto
        /// </summary>
        public virtual decimal SkontoProzent { get; set; }

        /// <summary>
        /// lZahlungsziel
        /// </summary>
        public virtual int Zahlungsziel { get; set; }

        /// <summary>
        /// datMahnung1
        /// </summary>
        public virtual LocalDate? Mahnungsdatum1 { get; set; }

        /// <summary>
        /// datMahnung2
        /// </summary>
        public virtual LocalDate? Mahnungsdatum2 { get; set; }

        /// <summary>
        /// datMahnung3
        /// </summary>
        public virtual LocalDate? Mahnungsdatum3 { get; set; }

        /// <summary>
        /// datMahnung4
        /// </summary>
        public virtual LocalDate? Mahnungsdatum4 { get; set; }

        /// <summary>
        /// szKundenLiefNr(20)
        /// </summary>
        public virtual string KundenLiefNr { get; set; }

        /// <summary>
        /// bMahnen
        /// </summary>
        public virtual bool Mahnen { get; set; }

        /// <summary>
        /// szMatchcode
        /// </summary>
        public virtual string Matchcode { get; set; }

        /// <summary>
        /// lErledigtStatus
        /// </summary>
        public virtual int ErledigtStatus { get; set; }

        /// <summary>
        /// szProgId(1)
        /// </summary>
        public virtual char ProgId { get; set; }

        /// <summary>
        /// lDruckFolge
        /// </summary>
        public virtual int DruckFolge { get; set; }

        /// <summary>
        /// datGedruckt
        /// </summary>
        public virtual LocalDate Gedruckt { get; set; }

        /// <summary>
        /// lMahnung1
        /// </summary>
        public virtual int Mahnung1 { get; set; }

        /// <summary>
        /// lMahnung2
        /// </summary>
        public virtual int Mahnung2 { get; set; }

        /// <summary>
        /// lMahnung3
        /// </summary>
        public virtual int Mahnung3 { get; set; }

        /// <summary>
        /// dftBetragDM
        /// </summary>
        public virtual decimal? BetragDM { get; set; }

        /// <summary>
        /// dftRestDM
        /// </summary>
        public virtual decimal? RestDM { get; set; }

        /// <summary>
        /// dftBetragEUR
        /// </summary>
        public virtual decimal? BetragEUR { get; set; }

        /// <summary>
        /// dftRestEUR
        /// </summary>
        public virtual decimal? RestEUR { get; set; }

        /// <summary>
        /// bStapel
        /// </summary>
        public virtual bool Stapel { get; set; }

        /// <summary>
        /// dftMahngebuehr
        /// </summary>
        public virtual decimal Mahngebuehr { get; set; }

        /// <summary>
        /// dftZinssatz
        /// </summary>
        public virtual decimal Zinssatz { get; set; }

        /// <summary>
        /// dftZinsen
        /// </summary>
        public virtual decimal Zinsen { get; set; }

        /// <summary>
        /// szAuftragsNr(20)
        /// </summary>
        public virtual string AuftragsNr { get; set; }

        /// <summary>
        /// lAuftragsKennung
        /// </summary>
        public virtual int Auftragskennung { get; set; }

        /// <summary>
        /// datFaellig
        /// </summary>
        public virtual LocalDate? Faelligkeitsdatum { get; set; }

        /// <summary>
        /// datSkonto
        /// </summary>
        public virtual LocalDate? SkontoDatum { get; set; }

        /// <summary>
        /// lZahlungszielSkonto2
        /// </summary>
        public virtual int ZahlungszielSkonto2 { get; set; }

        /// <summary>
        /// dftSkonto2
        /// </summary>
        public virtual decimal SkontoProzent2 { get; set; }

        /// <summary>
        /// dftWawiZahlung (Teilzahlungsbetrag?)
        /// </summary>
        public virtual decimal WarenwirtschaftZahlung { get; set; }

        /// <summary>
        /// bRueckgesetzt
        /// </summary>
        public virtual bool Rueckgesetzt { get; set; }

        /// <summary>
        /// bFixFaellig
        /// </summary>
        public virtual bool FixFaellig { get; set; }

        /// <summary>
        /// lTagVonMonat
        /// </summary>
        public virtual int TagVonMonat { get; set; }

        /// <summary>
        /// lTageVorlauf
        /// </summary>
        public virtual int TageVorlauf { get; set; }
    }
}
