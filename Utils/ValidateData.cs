namespace Patients.Utils
{
    public static class ValidateData
    {
        public static Object ValidateSQLData(Object o)
        {
            if (o == null) {
                return DBNull.Value;
            }
            return o;
        }
    }
}
