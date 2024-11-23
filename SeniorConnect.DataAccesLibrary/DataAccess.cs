using CoreDomain.Users;
using Microsoft.Data.SqlClient;

namespace SeniorConnect.DataAccesLibrary
{
    public class DataAccess
    {
        private readonly string _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SeniorConnect;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        private static SqlConnection OpenSqlConnection(string connectionString)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        protected List<User> GetAllUsers()
        {
            var users = new List<User>();

            string query = "SELECT [Id], [FirstName], [LastName], [Email], [Password] FROM [dbo].[User]";

            try
            {
                using (var connection = OpenSqlConnection(_connectionString))
                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var user = new User
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Email = reader.GetString(3),
                            Password = reader.GetString(4)
                        };

                        users.Add(user);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading data: " + ex.Message);
            }

            return users;
        }

        protected void SaveUser(User user)
        {
            string query = "INSERT INTO [SeniorConnect].[dbo].[User] ([FirstName], [LastName], [Email], [Password])";

            try
            {
                using (var connection = OpenSqlConnection(_connectionString))
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error saving data: " + ex.Message);

            }
        }
    }
}
