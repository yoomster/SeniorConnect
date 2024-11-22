using CoreDomain.Users;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorConnect.DataAccesLibrary
{
    public List<User> GetAllUsers()
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

    public void SaveUser()
    {
        // To implement: save functionality 

        string query = "INSERT INTO [SeniorConnect].[dbo].[User] ([FirstName], [LastName], [Email], [Password])";

        try
        {
            using (var connection = OpenSqlConnection(_connectionString))
            using (var command = new SqlCommand(query, connection))
            {

            }
        }
        catch (Exception ex)
        {

            Console.WriteLine("Error saving data: " + ex.Message);

        }
    }
}
