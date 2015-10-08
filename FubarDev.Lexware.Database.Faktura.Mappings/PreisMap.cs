using FluentNHibernate.Mapping;

using FubarDev.Lexware.Database.NhSupport;

namespace FubarDev.Lexware.Database.Faktura.Mappings
{
    public class PreisMap : ClassMap<Preis>
    {
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
