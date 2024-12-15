using CoreDomain.Users;
using Microsoft.Data.SqlClient;

namespace SeniorConnect.DataAccesLibrary
{
    public class DataAccess
    {
        private readonly string _connectionString = "";
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
