using System;

using NHibernate.Type;

namespace FubarDev.Lexware.Database.NhSupport
{
    public class GenericPersistentEnumType<T> : PersistentEnumType
    {
        public GenericPersistentEnumType()
            : base(typeof(T))
        {
        }
    }
}
