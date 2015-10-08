using FluentNHibernate.Mapping;

namespace FubarDev.Lexware.Database.Global.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Schema("LEXGLOBAL");
            Table("LXG_USER");
            Id(x => x.Id, "USER_ID");
            Map(x => x.Name, "USER_NAME");
            Map(x => x.Password, "PASSWORD");
        }
    }
}
