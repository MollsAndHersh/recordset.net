using Xunit;

namespace RecordsetNet.Tests
{
    public class DataTypeTests
    {
        [Fact]
        public void Supported_Type_Is_Converted()
        {
            var expected = ADODB.DataTypeEnum.adBoolean;

            var actual = new ADODB.DataTypeEnum();
            DataTypes.TryGetAdoTypeForClrType(typeof(bool), out actual);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Unsupported_Type_Is_Not_Converted()
        {
            bool expected = false;

            var type = new ADODB.DataTypeEnum();
            bool actual = DataTypes.TryGetAdoTypeForClrType(typeof(object), out type);

            Assert.Equal(expected, actual);
        }
    }
}
