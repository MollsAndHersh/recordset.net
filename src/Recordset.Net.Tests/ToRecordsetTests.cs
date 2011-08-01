using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADODB;
using NUnit.Framework;
using Recordset.Net;

namespace Recordset.Net.Tests
{
    [TestFixture]
    public class ToRecordsetTests
    {
        List<TestDto> input;
        ADODB.Recordset rs;

        [SetUp]
        public void Init()
        {
            input = new List<TestDto>();
            input.Add(new TestDto("string1", 1, true));
            input.Add(new TestDto("string2", 2, false));
            rs = input.ToRecordset();
        }

        [Test]
        public void Recordset_is_not_null()
        {
            Assert.That(rs != null);
        }
    }
}
