﻿using System;
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
    }
}
