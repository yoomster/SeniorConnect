using CoreDomain.Users;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace SeniorConnect.DataAccesLibrary
{
    public class DataAccess
    {
        private readonly string _connectionString;

        public DataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        private static SqlConnection OpenSqlConnection(string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public SqlConnection OpenSqlConnection()
        {
            return OpenSqlConnection(_connectionString);
        }
    }
}
