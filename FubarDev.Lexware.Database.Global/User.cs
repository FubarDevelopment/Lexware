using System.Net;

namespace FubarDev.Lexware.Database.Global
{
    public class User
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Password { get; set; }

        public virtual NetworkCredential CreateCredential()
        {
            return new NetworkCredential($"U{Id}", Password);
        }
    }
}
