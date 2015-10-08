using System;
using System.Data;

using NHibernate.Type;

namespace FubarDev.Lexware.Database.NhSupport
{
    public class LexwareDecimalType : DecimalType
    {
        /// <summary>
        /// When implemented by a class, gets the object in the 
        ///             <see cref="T:System.Data.IDataReader"/> for the Property.
        /// </summary>
        /// <param name="rs">The <see cref="T:System.Data.IDataReader"/> that contains the value.</param><param name="index">The index of the field to get the value from.</param>
        /// <returns>
        /// An object with the value from the database.
        /// </returns>
        public override object Get(IDataReader rs, int index)
        {
            var v = Convert.ToDouble(rs[index]);
            return ConvertToDecimal(v);
        }

        /// <summary>
        /// When implemented by a class, gets the object in the 
        ///             <see cref="T:System.Data.IDataReader"/> for the Property.
        /// </summary>
        /// <param name="rs">The <see cref="T:System.Data.IDataReader"/> that contains the value.</param><param name="name">The name of the field to get the value from.</param>
        /// <returns>
        /// An object with the value from the database.
        /// </returns>
        /// <remarks>
        /// Most implementors just call the <see cref="M:NHibernate.Type.NullableType.Get(System.Data.IDataReader,System.Int32)"/> 
        ///             overload of this method.
        /// </remarks>
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
