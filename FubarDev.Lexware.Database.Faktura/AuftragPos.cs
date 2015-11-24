//-----------------------------------------------------------------------
// <copyright file="AuftragPos.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using System;

using FubarDev.Lexware.Database.Shared;

namespace FubarDev.Lexware.Database.Faktura
{
    /// <summary>
    /// Vorlage für eine Position eines Auftrags
    /// </summary>
    public class AuftragPos : IAuditEntity // IEquatable<AboVorlagePos>
    {
        /// <summary>
        /// LNr
        /// </summary>
        public virtual int Id { get; set; }

        /// <summary>
        /// AuftragsNr
        /// </summary>
        public virtual string AuftragsNr { get; set; }

        /// <summary>
        /// AuftragsKennung
        /// </summary>
        public virtual int Auftragskennung { get; set; }

        /// <summary>
        /// LfdNr
        /// </summary>
        public virtual int LfdNr { get; set; }

        /// <summary>
        /// PosNr
        /// </summary>
        public virtual int PosNr { get; set; }

        /// <summary>
        /// PosText
        /// </summary>
        public virtual string PosText { get; set; }

        /// <summary>
        /// ArtikelNr
        /// </summary>
        public virtual string ArtikelNr { get; set; }

        /// <summary>
        /// lArtikelID
        /// </summary>
        public virtual Artikel ArtikelVonId { get; set; }

        /// <summary>
        /// Artikel_Bezeichnung
        /// </summary>
        public virtual string ArtikelBezeichnung { get; set; }

        /// <summary>
        /// szArtikel_Kurzbezeichnung
        /// </summary>
        public virtual string ArtikelKurzbezeichnung { get; set; }

        /// <summary>
        /// Artikel_Menge
        /// </summary>
        public virtual decimal ArtikelMenge { get; set; }

        /// <summary>
        /// Artikel_Preisfaktor
        /// </summary>
        public virtual decimal ArtikelPreisfaktor { get; set; }

        /// <summary>
        /// Summen_preis
        /// </summary>
        public virtual decimal SummenPreis { get; set; }

        /// <summary>
        /// Summen_rabatt
        /// </summary>
        public virtual decimal SummenRabatt { get; set; }

        /// <summary>
        /// Summen_rabatt_proz
        /// </summary>
        public virtual decimal SummenRabattProzent { get; set; }

        /// <summary>
        /// Summen_netto
        /// </summary>
        public virtual decimal SummenNetto { get; set; }

        /// <summary>
        /// Summen_brutto
        /// </summary>
        public virtual decimal SummenBrutto { get; set; }

        /// <summary>
        /// Summen_ust_proz
        /// </summary>
        public virtual decimal SummenUmsatzsteuerProzent { get; set; }

        /// <summary>
        /// Summen_ust_gesamt
        /// </summary>
        public virtual decimal SummenUmsatzsteuerGesamt { get; set; }

        /// <summary>
        /// Summen_ust_nach_Aufrab
        /// </summary>
        public virtual decimal SummenUmsatzsteuerNachAuftragsrabatt { get; set; }

        /// <summary>
        /// Summen_netto_nach_Aufrab
        /// </summary>
        public virtual decimal SummenNettoNachAuftragsrabatt { get; set; }

        /// <summary>
        /// Summen_brutto_nach_Aufrab
        /// </summary>
        public virtual decimal SummenBruttoNachAuftragsrabatt { get; set; }

        /// <summary>
        /// bMitAuftragsrabatt
        /// </summary>
        public virtual bool MitAuftragsrabatt { get; set; }

        /// <summary>
        /// dftArtikelpreisNetto
        /// </summary>
        public virtual decimal ArtikelpreisNetto { get; set; }

        /// <summary>
        /// dftArtikelpreisBrutto
        /// </summary>
        public virtual decimal ArtikelpreisBrutto { get; set; }

        /// <summary>
        /// fPreisManuell
        /// </summary>
        public virtual bool PreisManuell { get; set; }

        /// <summary>
        /// lPreisArt
        /// </summary>
        public virtual PreisArt PreisArt { get; set; }

        /// <summary>
        /// lPreisID
        /// </summary>
        public virtual Preis Preis { get; set; }

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
