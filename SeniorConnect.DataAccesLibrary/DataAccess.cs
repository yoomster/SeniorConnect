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

        internal async Task<SqlConnection> OpenSqlConnectionAsync()
        {
            var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();
            return connection;
        }
    }
}
