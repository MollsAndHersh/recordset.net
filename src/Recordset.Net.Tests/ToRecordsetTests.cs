using System.Collections.Generic;
using Xunit;

namespace RecordsetNet.Tests
{
    public class ToRecordsetTests
    {
        [Fact]
        public void Recordset_is_not_null()
        {
            var input = new List<int>();
            input.Add(0);

            var rs = input.ToRecordset();

            Assert.NotNull(rs);
        }
    }
}
