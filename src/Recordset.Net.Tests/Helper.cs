
namespace RecordsetNet.Tests
{
    public class Helper
    {
        public static bool FieldExistsInRecordset(ADODB.Recordset rs, string fieldName)
        {
            foreach (ADODB.Field field in rs.Fields)
            {                
                if (field.Name.ToLower() == fieldName.ToLower())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
