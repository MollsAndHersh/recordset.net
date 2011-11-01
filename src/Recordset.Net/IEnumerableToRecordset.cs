using System.Collections.Generic;

namespace Recordset.Net
{
    /// <summary>
    /// extension methods for IEnumerable
    /// </summary>
    public static class IEnumerableToRecordset
    {
        /// <summary>
        /// Creates an ADODB.Recordset from an System.Collections.Generic.IEnumerable<T>.
        /// </summary>
        /// <typeparam name="T">The type of the elements of input.</typeparam>
        /// <param name="input">The System.Collections.Generic.IEnumerable<T> to create an ADODB.Recordset from.</param>
        /// <returns>An ADODB.Recordset that contains elements from the input sequence.</returns>
        public static ADODB.Recordset ToRecordset<T>(this IEnumerable<T> input)
        {
            return null;
        }
    }
}
