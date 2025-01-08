using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace SeniorConnect.DataAccesLibrary
{
    internal class DataAccess
    {
        private readonly string _connectionString;

        public DataAccess(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
        }

        private async Task<SqlConnection> OpenSqlConnectionAsync(string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            await connection.OpenAsync(); 
            return connection;
        }

        internal async Task<SqlConnection> OpenSqlConnection()
        {
            return await OpenSqlConnectionAsync(_connectionString);
        }
    }
}
