using System;
using System.Collections.Generic;

namespace RecordsetNet
{
    /// <summary>
    /// extension methods for IEnumerable
    /// </summary>
    public static class IEnumerableToRecordset
    {
        /// <summary>
        /// Creates an ADODB.Recordset from an System.Collections.Generic.IEnumerable(T).
        /// </summary>
        /// <typeparam name="T">The type of the elements of input.</typeparam>
        /// <param name="input">The System.Collections.Generic.IEnumerable(T) to create an ADODB.Recordset from.</param>
        /// <returns>An ADODB.Recordset that contains elements from the input sequence.</returns>
        public static ADODB.Recordset ToRecordset<T>(this IEnumerable<T> input)
        {
            var rs = CreateEmptyRecordSetFromPoco(input);
            return rs;
        }

        /// <summary>
        /// Creates an empty Recordset with the fields and types from the IEnumerable(T).
        /// </summary>
        /// <typeparam name="T">The type of the elements of input.</typeparam>
        /// <param name="input">The System.Collections.Generic.IEnumerable(T) to create an ADODB.Recordset from.</param>
        /// <returns>An empty recordset that contains the same fields as T.</returns>
        private static ADODB.Recordset CreateEmptyRecordSetFromPoco<T>(IEnumerable<T> input)
        {
            var adoType = new ADODB.DataTypeEnum();

            if (DataTypes.TryGetAdoTypeForClrType(typeof(T), out adoType))
            {
                throw new ArgumentException("The T of IEnumerable<T> must be a custom POCO, not an ADO compatible type.", "input");
            }

            return new ADODB.Recordset();
        }
    }
}
