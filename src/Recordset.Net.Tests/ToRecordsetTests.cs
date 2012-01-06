using System;
using System.Collections.Generic;
using Xunit;

namespace RecordsetNet.Tests
{
    public class ToRecordsetTests
    {
        [Fact]
        public void Ado_Compatible_Type_Throws_ArgumentException()
        {
            var input = new List<int>();

            Assert.Throws<ArgumentException>(() => input.ToRecordset());
        }

        [Fact]
        public void Poco_Is_Converted_To_Recordset()
        {
            var input = new List<TestPoco>();
            var actual = input.ToRecordset();

            Assert.True(actual is ADODB.Recordset);
        }
    }
}
