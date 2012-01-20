using Xunit;

namespace RecordsetNet.Tests
{
    public class HelperTests
    {
        public ADODB.Recordset CreateRecordset()
        {
            var rs = new ADODB.Recordset();
            rs.Fields.Append("BoolValue", ADODB.DataTypeEnum.adBoolean);
            return rs;
        }

        [Fact]
        public void FieldExistsInRecordset_ExistingFieldWithExactCase_IsFound()
        {
            var rs = this.CreateRecordset();
            Assert.True(Helper.FieldExistsInRecordset(rs, "BoolValue"));
        }

        [Fact]
        public void FieldExistsInRecordset_ExistingFieldWithDifferentCase_IsFound()
        {
            var rs = this.CreateRecordset();
            Assert.True(Helper.FieldExistsInRecordset(rs, "boOlvalUe"));
        }

        [Fact]
        public void FieldExistsInRecordset_NotExistingField_IsNotFound()
        {
            var rs = this.CreateRecordset();
            Assert.False(Helper.FieldExistsInRecordset(rs, "foo"));
        }
    }
}
