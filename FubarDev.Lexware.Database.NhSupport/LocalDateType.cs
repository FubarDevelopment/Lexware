//-----------------------------------------------------------------------
// <copyright file="LocalDateType.cs" company="Fubar Development Junker">
//     Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>
// <author>Mark Junker</author>
//-----------------------------------------------------------------------

using System;
using System.Data;
using System.Globalization;
using System.Xml;

using NHibernate;
using NHibernate.Dialect;
using NHibernate.SqlTypes;
using NHibernate.Type;

using NodaTime;

namespace FubarDev.Lexware.Database.NhSupport
{
    /// <summary>
    /// Typ-Konvertierung zwischen DateTime und LocalDate
    /// </summary>
    public class LocalDateType : PrimitiveType
    {
        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="LocalDateType"/> Klasse.
        /// </summary>
        public LocalDateType()
            : base(SqlTypeFactory.Date)
        {
        }

        /// <inheritdoc/>
        public override string Name => "LocalDate";

        /// <inheritdoc/>
        public override Type ReturnedClass => typeof(LocalDate);

        /// <inheritdoc/>
        public override Type PrimitiveClass => typeof(LocalDate);

        /// <inheritdoc/>
        public override object DefaultValue => default(LocalDate);

        /// <inheritdoc/>
        public override void Set(IDbCommand cmd, object value, int index)
        {
            var parm = (IDataParameter)cmd.Parameters[index];
            if (value == null)
            {
                parm.Value = DBNull.Value;
            }
            else
            {
                var localDate = (LocalDate)value;
                parm.DbType = DbType.Date;
                parm.Value = DateTime.SpecifyKind(
                    new DateTime(localDate.Year, localDate.Month, localDate.Day),
                    DateTimeKind.Local);
            }
        }

        /// <inheritdoc/>
        public override object Get(IDataReader rs, int index)
        {
            try
            {
                var dateTime = Convert.ToDateTime(rs[index]);
                return new LocalDate(dateTime.Year, dateTime.Month, dateTime.Day);
            }
            catch (Exception ex)
            {
                throw new FormatException(string.Format(CultureInfo.InvariantCulture, "Input string '{0}' was not in the correct format.", rs[index]), ex);
            }
        }

        /// <inheritdoc/>
        public override object Get(IDataReader rs, string name)
        {
            return Get(rs, rs.GetOrdinal(name));
        }

        /// <inheritdoc/>
        public override object FromStringValue(string xml)
        {
            var dateTime = XmlConvert.ToDateTimeOffset(xml).LocalDateTime;
            return new LocalDate(dateTime.Year, dateTime.Month, dateTime.Day);
        }

        /// <inheritdoc/>
        public override string ObjectToSQLString(object value, Dialect dialect)
        {
            return ((LocalDate)value).ToString("'yyyy-MM-dd'", CultureInfo.InvariantCulture);
        }

        /// <inheritdoc/>
        public override bool IsEqual(object x, object y)
        {
            if (x == y)
                return true;
            if (x == null || y == null)
                return false;

            return ((LocalDate)x).Equals(y);
        }

        /// <inheritdoc/>
        public override int GetHashCode(object x, EntityMode entityMode)
        {
            var date = (LocalDate)x;
            var hashCode = 1;
            unchecked
            {
                hashCode = (31 * hashCode) + date.Day;
                hashCode = (31 * hashCode) + date.Month;
                hashCode = (31 * hashCode) + date.Year;
            }
            return hashCode;
        }

        /// <inheritdoc/>
        public override string ToString(object val)
        {
            return ((LocalDate)val).ToString("d", null);
        }
    }
}
