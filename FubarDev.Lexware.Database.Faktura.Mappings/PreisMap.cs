//-----------------------------------------------------------------------
// <copyright file="PreisMap.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using FluentNHibernate.Mapping;

using FubarDev.Lexware.Database.NhSupport;

namespace FubarDev.Lexware.Database.Faktura.Mappings
{
    /// <summary>
    /// NHibernate-Mapping für <see cref="Preis"/>
    /// </summary>
    public class PreisMap : ClassMap<Preis>
    {
        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="PreisMap"/> Klasse.
        /// </summary>
        public PreisMap()
        {
            Table("FK_Preis");

            Id(m => m.Id, "lID").GeneratedBy.Custom<LexwareIdTableGenerator>(p =>
            {
                p.AddParam(LexwareIdTableGenerator.TargetTableNameParam, "FK_Preis")
                    .AddParam(LexwareIdTableGenerator.TargetTableIdColumnNameParam, "lID");
            });

            References(r => r.Artikel, "lArtikelID");
            References(r => r.Aktion, "lAktionsID").NotFound.Ignore();
            Map(m => m.Verkaufspreis, "dftVK");
            Map(m => m.Bemerkung, "szBemerkung");
            Map(m => m.Gesperrt, "fGesperrt");
            Map(m => m.Rabattfaehig, "fRabattfaehig");
        }
    }
}
