//-----------------------------------------------------------------------
// <copyright file="KundeMap.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using FluentNHibernate.Mapping;

namespace FubarDev.Lexware.Database.Faktura.Mappings
{
    /// <summary>
    /// Fluent NHibernate-Mapping für <see cref="Kunde"/>
    /// </summary>
    public class KundeMap : ClassMap<Kunde>
    {
        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="KundeMap"/> Klasse.
        /// </summary>
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
                c.Map(p => p.Email);
                c.Map(p => p.Vorname);
                c.Map(p => p.Name);
                c.Map(p => p.Strasse);
                c.Map(p => p.HausNr);
                c.Map(p => p.Ansprech);
                c.Map(p => p.Zusatz);
            });

            Map(m => m.Inaktiv, "bInaktiv");

            Map(m => m.UserDefined1, "szUserdefined1").Length(50);
            Map(m => m.UserDefined2, "szUserdefined2").Length(50);
            Map(m => m.UserDefined3, "szUserdefined3").Length(50);
            Map(m => m.UserDefined4, "szUserdefined4").Length(50);
            Map(m => m.UserDefined5, "szUserdefined5").Length(50);
            Map(m => m.UserDefined6, "szUserdefined6").Length(50);

            Map(m => m.BDSGStatus, "lBDSG_Status");
            References(m => m.BDSGText, "lBDSGTextID").Nullable();
            Map(m => m.BDSGZeitpunkt, "datBDSG");

            Map(m => m.Created, "System_created");
            Map(m => m.CreatedBy, "System_created_user");
            Map(m => m.Updated, "System_updated");
            Map(m => m.UpdatedBy, "System_updated_user");
        }
    }
}
