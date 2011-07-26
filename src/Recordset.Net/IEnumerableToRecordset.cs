using System.Collections.Generic;

namespace Recordset.Net
{
    public static class IEnumerableToRecordset
    {
        public static ADODB.Recordset ToRecordset<T>(this IEnumerable<T> input)
        {
            return null;
        }
    }
}
