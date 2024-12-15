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

        private async Task<SqlConnection> OpenSqlConnectionAsync(string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            await connection.OpenAsync(); 
            return connection;

        }


        public async Task<SqlConnection> OpenSqlConnectionAsync()
        {
            return await OpenSqlConnectionAsync(_connectionString);
        }
    }
}
