//-----------------------------------------------------------------------
// <copyright file="PropertyToColumnNameConvention.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using System;
using System.Linq;

using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

using NodaTime;

namespace FubarDev.Lexware.Database
{
    public class PropertyToColumnNameConvention : IPropertyConvention
    {
        public const string DefaultName = "auto";

        public void Apply(IPropertyInstance instance)
        {
            if (instance.Columns.All(x => string.Equals(x.Name, DefaultName, StringComparison.Ordinal)))
            {
                var systemType = instance.Type.GetUnderlyingSystemType();
                if (systemType == typeof(int))
                {
                    instance.Column("l" + instance.Name);
                }
                else if (systemType == typeof(string))
                {
                    instance.Column("sz" + instance.Name);
                }
                else if (systemType == typeof(decimal))
                {
                    instance.Column("dft" + instance.Name);
                }
                else if (systemType == typeof(bool))
                {
                    instance.Column("b" + instance.Name);
                }
                else if (systemType == typeof(LocalDate))
                {
                    instance.Column("dat" + instance.Name);
                }
            }
        }
    }
}
