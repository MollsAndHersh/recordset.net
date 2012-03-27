using System;
using System.Collections.Generic;
using Xunit;

namespace RecordsetNet.Tests
{
    public class IEnumerableToRecordsetTests
    {
        [Fact]
        public void ToRecordset_AdoCompatibleType_ThrowsArgumentException()
        {
            var input = new List<int>();

            Assert.Throws<ArgumentException>(() => input.ToRecordset());
        }

        [Fact]
        public void ToRecordset_EmptyPocoList_IsConvertedToRecordset()
        {
            var input = new List<TestPoco>();
            var result = input.ToRecordset();

            Assert.True(result is ADODB.Recordset);
        }

        [Fact]
        public void ToRecordset_EmptyPocoList_AllFieldsAreConverted()
        {
            var input = new List<TestPoco>();
            var rs = input.ToRecordset();

            Assert.True(Helper.FieldExistsInRecordset(rs,"stringvalue"));
            Assert.True(Helper.FieldExistsInRecordset(rs,"int32value"));
            Assert.True(Helper.FieldExistsInRecordset(rs,"boolvalue"));
        }

        [Fact]
        public void ToRecordset_EmptyPocoList_NumberOfFieldsIsCorrect()
        {
            var input = new List<TestPoco>();
            var rs = input.ToRecordset();

            Assert.Equal(rs.Fields.Count, 3);
        }

        [Fact]
        public void ToRecordset_EmptyPocoListWithPrivateField_FieldIsNotConverted()
        {
            var input = new List<TestPocoPrivate>();
            var rs = input.ToRecordset();

            Assert.False(Helper.FieldExistsInRecordset(rs, "privatevalue"));
        }

        [Fact]
        public void ToRecordset_EmptyPocoListWithUnsupportedField_FieldIsNotConverted()
        {
            var input = new List<TestPocoUnsupported>();
            var rs = input.ToRecordset();

            Assert.False(Helper.FieldExistsInRecordset(rs, "unsupportedvalue"));       
        }

        [Fact]
        public void ToRecordset_EmptyPocoListWithBaseClass_BaseClassFieldsAreConverted()
        {
            var input = new List<TestPocoDerived>();
            var rs = input.ToRecordset();

            Assert.True(Helper.FieldExistsInRecordset(rs, "stringvalue"));
            Assert.True(Helper.FieldExistsInRecordset(rs, "int32value"));
            Assert.True(Helper.FieldExistsInRecordset(rs, "boolvalue"));
            Assert.True(Helper.FieldExistsInRecordset(rs, "boolvalueinderived"));
        }

        [Fact]
        public void ToRecordset_PocoListWith3Items_AllItemsAreConverted()
        {
            var input = new List<TestPoco>();

            for (int i = 0; i < 3; i++)
            {
                var item = new TestPoco
                {
                    BoolValue = true,
                    Int32Value = i,
                    StringValue = "foo"
                };

                input.Add(item);
            }

            var rs = input.ToRecordset();

            Assert.Equal(3, rs.RecordCount);
        }

        [Fact]
        public void ToRecordset_PocoList_FieldsAreEqual()
        {
            var input = new List<TestPoco>();
            var expected = new TestPoco { BoolValue = true, Int32Value = 1, StringValue = "foo" };
            input.Add(expected);

            var actual = input.ToRecordset();

            Assert.Equal((bool)actual.Fields["BoolValue"].Value, expected.BoolValue);
            Assert.Equal((int)actual.Fields["Int32Value"].Value, expected.Int32Value);
            Assert.Equal((string)actual.Fields["StringValue"].Value, expected.StringValue);
        }

    }
}
