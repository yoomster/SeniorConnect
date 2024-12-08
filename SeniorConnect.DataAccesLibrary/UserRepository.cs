﻿using CoreDomain.Users;
using Microsoft.Data.SqlClient;
using SeniorConnect.Domain.Contracts;

namespace SeniorConnect.DataAccesLibrary
{
    public class UserRepository : IUserRepository
    {
        //creating, reading, updating, or deleting records
        private readonly DataAccess _dataAccess;

        

        public UserRepository(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public void SaveUserToDB(User user)
        {
            string query = "INSERT INTO [SeniorConnect.SQLServerDB].[dbo].[User] ([FirstName], [LastName], [Email], [Password]) " +
                           "VALUES (@FirstName, @LastName, @Email, @Password)";

            try
            {
                using (var connection = _dataAccess.OpenSqlConnection())
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Password", user.Password);  // password hash needed?

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // change to handle error!!!
                Console.WriteLine("Error saving data: " + ex.Message);
            }
        }


        public List<User> GetUsers()
        {
            var users = new List<User>();

            string query = "SELECT [Id], [FirstName], [LastName], [Email], [Password] FROM [SeniorConnect.SQLServerDB].[dbo].[User]";

            try
            {
                using (var connection = _dataAccess.OpenSqlConnection())
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
                // change to handle error!!!
                Console.WriteLine("Error loading data: " + ex.Message);
            }

            return users;

        }

        bool IUserRepository.IsDuplicateEmail(string email)
        {
            return true;
            //     return Users.Any(u => u.Email == email);
        }

        public User UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
