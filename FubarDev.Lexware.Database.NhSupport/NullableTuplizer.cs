//-----------------------------------------------------------------------
// <copyright file="NullableTuplizer.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using System.Collections;

using FubarDev.Lexware.Database.Shared;

using NHibernate.Engine;
using NHibernate.Mapping;
using NHibernate.Tuple.Entity;

namespace FubarDev.Lexware.Database.NhSupport
{
    public class NullableTuplizer : PocoEntityTuplizer
    {
        public NullableTuplizer(EntityMetamodel entityMetamodel, PersistentClass mappedEntity)
            : base(entityMetamodel, mappedEntity)
        {
        }

        /// <inheritdoc/>
        public override object[] GetPropertyValuesToInsert(
            object entity, IDictionary mergeMap, ISessionImplementor session)
        {
            object[] values = base.GetPropertyValuesToInsert(entity, mergeMap, session);

            // dirty hack 1
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == null && typeof(IZeroAsNullEntity).IsAssignableFrom(getters[i].ReturnType))
                {
                    values[i] = ProxyFactory.GetProxy(0, null);
                }
            }
            return values;
        }

        /// <inheritdoc/>
        public override object[] GetPropertyValues(object entity)
        {
            object[] values = base.GetPropertyValues(entity);

            // dirty hack 2
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == null && typeof(IZeroAsNullEntity).IsAssignableFrom(getters[i].ReturnType))
                {
                    values[i] = ProxyFactory.GetProxy(0, null);
                }
            }
            return values;
        }

        /// <inheritdoc/>
        public override void SetPropertyValues(object entity, object[] values)
        {
            // dirty hack 3.
            for (int i = 0; i < values.Length; i++)
            {
                if (typeof(IZeroAsNullEntity).IsAssignableFrom(getters[i].ReturnType)
                    && ((IZeroAsNullEntity)values[i]).Id == 0)
                {
                    values[i] = null;
                }
            }
            base.SetPropertyValues(entity, values);
        }
    }
}