//-----------------------------------------------------------------------
// <copyright file="AboVorlage.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;

using FubarDev.Lexware.Database.Shared;

using NodaTime;

namespace FubarDev.Lexware.Database.Faktura
{
    public class AboVorlage : IAuditEntity // IEquatable<AboVorlage>
    {
        /// <summary>
        /// SheetNr
        /// </summary>
        public virtual int SheetNr { get; set; }

        /// <summary>
        /// AuftragsNr
        /// </summary>
        public virtual string AuftragsNr { get; set; }

        /// <summary>
        /// AuftragsKennung
        /// </summary>
        public virtual int Auftragskennung { get; set; }

        /// <summary>
        /// KundenNr
        /// </summary>
        public virtual string KundenNr { get; set; }

        /// <summary>
        /// Anschrift_Anrede, Anschrift_Firma, Anschrift_Ort, Anschrift_FirmaPlz
        /// </summary>
        public virtual Adresse Anschrift { get; set; }

        /// <summary>
        /// Summen_netto_haupt
        /// </summary>
        public virtual decimal SummenNettoHaupt { get; set; }

        /// <summary>
        /// Summen_brutto_haupt
        /// </summary>
        public virtual decimal SummenBruttoHaupt { get; set; }

        /// <summary>
        /// Summen_netto_neben
        /// </summary>
        public virtual decimal SummenNettoNeben { get; set; }

        /// <summary>
        /// Summen_brutto_neben
        /// </summary>
        public virtual decimal SummenBruttoNeben { get; set; }

        /// <summary>
        /// Summen_ust_gesamt
        /// </summary>
        public virtual decimal SummenUmsatzsteuerGesamt { get; set; }

        /// <summary>
        /// Summen_abschlag_netto
        /// </summary>
        public virtual decimal SummenAbschlagNetto { get; set; }

        /// <summary>
        /// Summen_abschlag_brutto
        /// </summary>
        public virtual decimal SummenAbschlagBrutto { get; set; }

        /// <summary>
        /// Summen_abschlag_ust
        /// </summary>
        public virtual decimal SummenAbschlagUmsatzsteuer { get; set; }

        /// <summary>
        /// Summen_abschlag_forderung
        /// </summary>
        public virtual decimal SummenAbschlagForderung { get; set; }

        /// <summary>
        /// Summen_abschlag_erhalten
        /// </summary>
        public virtual decimal SummenAbschlagErhalten { get; set; }

        /// <summary>
        /// Summen_gesamt
        /// </summary>
        public virtual decimal SummenGesamt { get; set; }

        /// <summary>
        /// tsAboBegin
        /// </summary>
        public virtual LocalDate? AboBeginn { get; set; }

        /// <summary>
        /// tsAboEnde
        /// </summary>
        public virtual LocalDate? AboEnde { get; set; }

        /// <summary>
        /// fAboAbgeschlossen
        /// </summary>
        public virtual bool AboAbgeschlossen { get; set; }

        /// <summary>
        /// Konditionen_PreisgrpNr
        /// </summary>
        public virtual Preisgruppe KonditionenPreisgruppe { get; set; }

        /// <summary>
        /// Konditionen_Rabatt
        /// </summary>
        public virtual decimal KonditionenRabatt { get; set; }

        /// <summary>
        /// Konditionen_Rabatt_Proz
        /// </summary>
        public virtual decimal KonditionenRabattProzent { get; set; }

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

        /// <summary>
        /// Positionen
        /// </summary>
        public virtual IList<AboVorlagePos> Positionen { get; set; }
    }
}
