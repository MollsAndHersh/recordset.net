using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Recordset.Net.Tests
{
    public class TestDto
    {
        public TestDto(string stringvalue, int int32value, bool boolvalue)
        {
            this.StringValue = stringvalue;
            this.Int32Value = int32value;
            this.BoolValue = boolvalue;
        }

        public string StringValue { get; set; }
        public int Int32Value { get; set; }
        public bool BoolValue { get; set; }
    }
}
