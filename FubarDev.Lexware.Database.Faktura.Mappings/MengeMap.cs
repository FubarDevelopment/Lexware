using FluentNHibernate.Mapping;

namespace FubarDev.Lexware.Database.Faktura.Mappings
{
    public class MengeMap : ClassMap<Menge>
    {
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
