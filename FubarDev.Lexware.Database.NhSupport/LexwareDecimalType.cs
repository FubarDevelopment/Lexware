//-----------------------------------------------------------------------
// <copyright file="LexwareDecimalType.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using System;
using System.Data;

using NHibernate.Type;

namespace FubarDev.Lexware.Database.NhSupport
{
    /// <summary>
    /// Dieser Datentyp wird verwendet um die in der Datenbank als <see cref="double"/> hinterlegten Daten
    /// in den Entitäten als <see cref="decimal"/> ansprechen zu können.
    /// </summary>
    public class LexwareDecimalType : DecimalType
    {
        /// <inheritdoc/>
        public override object Get(IDataReader rs, int index)
        {
            var v = Convert.ToDouble(rs[index]);
            return ConvertToDecimal(v);
        }

        /// <inheritdoc/>
        public override object Get(IDataReader rs, string name)
        {
            var v = Convert.ToDouble(rs[name]);
            return ConvertToDecimal(v);
        }

        private static decimal ConvertToDecimal(double value)
        {
            return (decimal)Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }
    }
}
