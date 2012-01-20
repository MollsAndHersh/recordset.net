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
        public void ToRecordset_PocoList_IsConvertedToRecordset()
        {
            var input = new List<TestPoco>();
            var result = input.ToRecordset();

            Assert.True(result is ADODB.Recordset);
        }

        [Fact]
        public void ToRecordset_PocoList_AllFieldsAreConverted()
        {
            var input = new List<TestPoco>();
            var rs = input.ToRecordset();

            Assert.True(Helper.FieldExistsInRecordset(rs,"stringvalue"));
            Assert.True(Helper.FieldExistsInRecordset(rs,"int32value"));
            Assert.True(Helper.FieldExistsInRecordset(rs,"boolvalue"));
        }

        [Fact]
        public void ToRecordset_PocoList_NumberOfFieldsIsCorrect()
        {
            var input = new List<TestPoco>();
            var rs = input.ToRecordset();

            Assert.Equal(rs.Fields.Count, 3);
        }

        [Fact]
        public void ToRecordset_PocoListWithPrivateField_FieldIsNotConverted()
        {
            var input = new List<TestPocoPrivate>();
            var rs = input.ToRecordset();

            Assert.False(Helper.FieldExistsInRecordset(rs, "privatevalue"));
        }

        [Fact]
        public void ToRecordset_PocoListWithUnsupportedField_FieldIsNotConverted()
        {
            var input = new List<TestPocoUnsupported>();
            var rs = input.ToRecordset();

            Assert.False(Helper.FieldExistsInRecordset(rs, "unsupportedvalue"));       
        }

        [Fact]
        public void ToRecordset_PocoListWithBaseClass_BaseClassFieldsAreConverted()
        {
            var input = new List<TestPocoDerived>();
            var rs = input.ToRecordset();

            Assert.True(Helper.FieldExistsInRecordset(rs, "stringvalue"));
            Assert.True(Helper.FieldExistsInRecordset(rs, "int32value"));
            Assert.True(Helper.FieldExistsInRecordset(rs, "boolvalue"));
        }
    }
}
