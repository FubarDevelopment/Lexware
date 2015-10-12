//-----------------------------------------------------------------------
// <copyright file="MengeMap.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using FluentNHibernate.Mapping;

namespace FubarDev.Lexware.Database.Faktura.Mappings
{
    /// <summary>
    /// NHibernate-Mapping für <see cref="Menge"/>
    /// </summary>
    public class MengeMap : ClassMap<Menge>
    {
        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="MengeMap"/> Klasse.
        /// </summary>
        public MengeMap()
        {
            Table("FK_Menge");

            CompositeId()
                .KeyProperty(p => p.Nummer, "MengenNr")
                .KeyProperty(p => p.ArtikelNr);

            Map(m => m.Anzahl, "Menge");

            Map(m => m.Created, "System_created");
            Map(m => m.CreatedBy, "System_created_user");
            Map(m => m.Updated, "System_updated");
            Map(m => m.UpdatedBy, "System_updated_user");
        }
    }
}
