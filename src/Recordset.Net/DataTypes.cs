using System;
using System.Collections.Generic;

namespace RecordsetNet
{
    /// <summary>
    /// Converts CLR types to ADODB types.
    /// </summary>
    internal static class DataTypes
    {
        private static readonly Dictionary<Type, ADODB.DataTypeEnum> Types
            = new Dictionary<Type, ADODB.DataTypeEnum>()
            {
                { typeof(Boolean), ADODB.DataTypeEnum.adBoolean },
                { typeof(Byte), ADODB.DataTypeEnum.adUnsignedTinyInt },
                { typeof(Char), ADODB.DataTypeEnum.adChar },
                { typeof(DateTime), ADODB.DataTypeEnum.adDate },
                { typeof(Decimal), ADODB.DataTypeEnum.adDecimal },
                { typeof(Double), ADODB.DataTypeEnum.adDouble },
                { typeof(Guid), ADODB.DataTypeEnum.adVarWChar },
                { typeof(Int16), ADODB.DataTypeEnum.adSmallInt },
                { typeof(Int32), ADODB.DataTypeEnum.adInteger },
                { typeof(Int64), ADODB.DataTypeEnum.adBigInt },
                { typeof(SByte), ADODB.DataTypeEnum.adTinyInt },
                { typeof(Single), ADODB.DataTypeEnum.adSingle },
                { typeof(String), ADODB.DataTypeEnum.adVarWChar },
                { typeof(UInt16), ADODB.DataTypeEnum.adUnsignedSmallInt },
                { typeof(UInt32), ADODB.DataTypeEnum.adUnsignedInt },
                { typeof(UInt64), ADODB.DataTypeEnum.adUnsignedBigInt }
            };

        /// <summary>
        /// Get the appropriate ADODB type for a given CLR type.
        /// </summary>
        /// <param name="clrType">The CLR type to look for.</param>
        /// <param name="adoType">The ADODB type that matches the CLR type, if any.</param>
        /// <returns>True if an ADODB type was found.</returns>
        public static bool TryGetAdoTypeForClrType(Type clrType, out ADODB.DataTypeEnum adoType)
        {
            return Types.TryGetValue(clrType, out adoType);
        }
    }
}
