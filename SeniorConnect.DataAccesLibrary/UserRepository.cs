﻿using Microsoft.Data.SqlClient;
using SeniorConnect.Application.Interfaces;
using SeniorConnect.Domain;

namespace SeniorConnect.DataAccesLibrary
{
    //MAKE ALL METHOD INTERNAL, NO DI ALLOWED TO UI LAYER!
    internal class UserRepository : IUserRepository
    {
        private readonly DataAccess _dataAccess;

        internal UserRepository(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public async Task<int> CreateAccountToDBAsync(User user)
        {
            string query = @"
            INSERT INTO [dbo].[Users] 
            (FirstName, LastName, Email, Password, DateOfBirth, Gender, Origin, MaritalStatus, DateOfRegistration, StreetName, HouseNumber, Zipcode, City, Country)
            VALUES(@FirstName, @LastName, @Email, @Password, @DateOfBirth, @Gender, @Origin, @MaritalStatus, @DateOfRegistration, @StreetName, @HouseNumber, @Zipcode, @City, @Country);
            SELECT SCOPE_IDENTITY();"; // gets the new UserId

            using (var connection = await _dataAccess.OpenSqlConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                command.Parameters.AddWithValue("@Gender", user.Gender);
                command.Parameters.AddWithValue("@Origin", user.Origin);
                command.Parameters.AddWithValue("@MaritalStatus", user.MaritalStatus);
                //command.Parameters.AddWithValue("@MaritalStatus", (int)user.MaritalStatus);
                command.Parameters.AddWithValue("@DateOfRegistration", user.DateOfRegistration);
                command.Parameters.AddWithValue("@StreetName", user.StreetName);
                command.Parameters.AddWithValue("@HouseNumber", user.HouseNumber);
                command.Parameters.AddWithValue("@Zipcode", user.Zipcode);
                command.Parameters.AddWithValue("@City", user.City);
                command.Parameters.AddWithValue("@Country", user.Country);

                var result = await command.ExecuteScalarAsync();
                return Convert.ToInt32(result); // UserId for login and personal welcome message/page
            }
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            string query = @"SELECT [UserId], [FirstName], [LastName], [Email], [Password], 
                            [DateOfBirth], [Gender], [Origin], [DateOfRegistration], 
                            [StreetName], [HouseNumber], [Zipcode], [City], [Country]  
                     FROM [dbo].[Users] 
                     WHERE [UserId] = @UserId";

            using (var connection = await _dataAccess.OpenSqlConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserId", id);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new User () 
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Email = reader.GetString(3),
                            Password = reader.GetString(4),
                            DateOfBirth = DateOnly.FromDateTime(reader.GetDateTime(5)),
                            Gender = reader.GetString(6)[0],
                            Origin = reader.GetString(7),
                            DateOfRegistration = DateOnly.FromDateTime(reader.GetDateTime(8)),
                            StreetName = reader.GetString(9),
                            HouseNumber = reader.GetString(10),
                            Zipcode = reader.GetString(11),
                            City = reader.GetString(12),
                            Country = reader.GetString(13)
                        };
                    }
                }
            }

            return null; 
        }

        public async Task<List<User>> GetAllAsync()
        {
            string query = @"SELECT [UserId], [FirstName], [LastName], [Email], [Password], 
                            [DateOfBirth], [Gender], [Origin], [DateOfRegistration], 
                            [StreetName], [HouseNumber], [Zipcode], [City], [Country]  
                     FROM [dbo].[Users]";

            var users = new List<User>();

            using (var connection = await _dataAccess.OpenSqlConnection())
            using (var command = new SqlCommand(query, connection))
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    users.Add(new User
                    {
                        Id = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Email = reader.GetString(3),
                        Password = reader.GetString(4),
                        DateOfBirth = DateOnly.FromDateTime(reader.GetDateTime(5)),
                        Gender = reader.GetString(6)[0],
                        Origin = reader.GetString(7),
                        DateOfRegistration = DateOnly.FromDateTime(reader.GetDateTime(8)),
                        StreetName = reader.GetString(9),
                        HouseNumber = reader.GetString(10),
                        Zipcode = reader.GetString(11),
                        City = reader.GetString(12),
                        Country = reader.GetString(13)
                    });
                }
            }

            return users;
        }

        public async Task<bool> UpdateAccountAsync(User user)
        {
            string query = @"UPDATE [dbo].[Users]
                     SET [FirstName] = @FirstName, 
                         [LastName] = @LastName, 
                         [Email] = @Email, 
                         [Password] = @Password, 
                         [DateOfBirth] = @DateOfBirth, 
                         [Gender] = @Gender, 
                         [Origin] = @Origin, 
                         [DateOfRegistration] = @DateOfRegistration, 
                         [StreetName] = @StreetName, 
                         [HouseNumber] = @HouseNumber, 
                         [Zipcode] = @Zipcode, 
                         [City] = @City, 
                         [Country] = @Country
                     WHERE [UserId] = @UserId";

            using (var connection = await _dataAccess.OpenSqlConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserId", user.Id);
                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@Email", user.Email);
                command.Parameters.AddWithValue("@Password", user.Password);
                command.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                command.Parameters.AddWithValue("@Gender", user.Gender);
                command.Parameters.AddWithValue("@Origin", user.Origin);
                command.Parameters.AddWithValue("@DateOfRegistration", user.DateOfRegistration);
                command.Parameters.AddWithValue("@StreetName", user.StreetName);
                command.Parameters.AddWithValue("@HouseNumber", user.HouseNumber);
                command.Parameters.AddWithValue("@Zipcode", user.Zipcode);
                command.Parameters.AddWithValue("@City", user.City);
                command.Parameters.AddWithValue("@Country", user.Country);

                var rowsAffected = await command.ExecuteNonQueryAsync();
                return rowsAffected > 0; // Return true if successful
            }
        }

        public async Task<bool> DeleteAccountAsync(int userId)
        {
            string query = @"DELETE FROM [dbo].[Users] WHERE [UserId] = @UserId";

            using (var connection = await _dataAccess.OpenSqlConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@UserId", userId);

                var rowsAffected = await command.ExecuteNonQueryAsync();
                return rowsAffected > 0; // Return true if successful
            }
        }

        public async Task<bool> IsEmailRegistered(string email)
        {
            string query = @"SELECT COUNT(*) 
                             FROM [dbo].[Users] 
                             WHERE [Email] = @Email";

            using (var connection = await _dataAccess.OpenSqlConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", email);

                var result = await command.ExecuteScalarAsync();
                return (int)result > 0; 
            }
        }
    }
}
