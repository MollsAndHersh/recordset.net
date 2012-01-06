using Xunit;

namespace RecordsetNet.Tests
{
    public class DataTypeTests
    {
        [Fact]
        public void TryGetAdoTypeForClrType_SupportedType_IsConverted()
        {
            var expected = ADODB.DataTypeEnum.adBoolean;

            var actual = new ADODB.DataTypeEnum();
            DataTypes.TryGetAdoTypeForClrType(typeof(bool), out actual);

            Assert.Equal(expected, actual);
        }

        [Fact]
        public void TryGetAdoTypeForClrType_UnsupportedType_IsNotConverted()
        {
            bool expected = false;

            var type = new ADODB.DataTypeEnum();
            bool actual = DataTypes.TryGetAdoTypeForClrType(typeof(object), out type);

            Assert.Equal(expected, actual);
        }
    }
}
