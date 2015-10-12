//-----------------------------------------------------------------------
// <copyright file="PreismatrixMap.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using FluentNHibernate.Mapping;

namespace FubarDev.Lexware.Database.Faktura.Mappings
{
    /// <summary>
    /// NHibernate-Mapping für <see cref="Preismatrix"/>
    /// </summary>
    public class PreismatrixMap : ClassMap<Preismatrix>
    {
        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="PreismatrixMap"/> Klasse.
        /// </summary>
        public PreismatrixMap()
        {
            Table("FK_Preismatrix");

            CompositeId()
                .KeyReference(
                    p => p.Menge,
                    m =>
                    {
                        m.Not.Lazy();
                    },
                    "MengeNr",
                    "ArtikelNr")
                .KeyReference(p => p.Preisgruppe, "PreisgrpNr");

            Map(m => m.Verkaufspreis, "Vk_preis");
            Map(m => m.VerkaufspreisEuro, "Vk_preis_eur");

            Map(m => m.Created, "System_created");
            Map(m => m.CreatedBy, "System_created_user");
            Map(m => m.Updated, "System_updated");
            Map(m => m.UpdatedBy, "System_updated_user");
        }
    }
}
