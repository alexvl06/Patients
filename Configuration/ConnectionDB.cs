namespace Patients.Utils
{
    public class ConnectionDB
    {
        private string connectionString = string.Empty;
        public void ConnectionDb()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            connectionString = builder.GetSection("ConnectionStrings:MasterConnection").Value;
        }

        public string SQLString()
        {
            ConnectionDb();
            return connectionString;
        }
    }
}
