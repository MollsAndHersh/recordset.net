﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
            var adoType = new ADODB.DataTypeEnum();

            if (DataTypes.TryGetAdoTypeForClrType(typeof(T), out adoType))
            {
                throw new ArgumentException("The T of IEnumerable<T> must be a custom POCO, not an ADO compatible type.", "input");
            }

            var rs = new ADODB.Recordset();
            var type = typeof(T);

            BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
            PropertyInfo[] properties = type.GetProperties(flags);

            // create properties
            foreach (var property in properties)
            {
                if (DataTypes.TryGetAdoTypeForClrType(property.PropertyType, out adoType))
                {
                    int definedSize = 0;

                    if (property.PropertyType == typeof(string))
                    {
                        // TODO: set string size to length of longest string in POCO?
                        definedSize = 1000;
                    }

                    if (property.PropertyType == typeof(Guid))
                    {
                        definedSize = 38;
                    }

                    rs.Fields.Append(property.Name, adoType, definedSize, ADODB.FieldAttributeEnum.adFldIsNullable);
                }
            }

            // insert data
            rs.Open();

            if (input.Any())
            {
                foreach (var item in input)
                {
                    rs.AddNew();

                    foreach (var property in properties)
                    {
                        var value = property.GetValue(item, null);

                        if (property.PropertyType == typeof(Guid))
                        {
                            value = value.ToString();
                        }

                        if (value != null)
                        {
                            rs.Fields[property.Name].Value = value;
                        }
                    }

                    rs.Update();
                }
            }

            return rs;
        }
    }
}
