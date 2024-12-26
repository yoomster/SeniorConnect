using CoreDomain;
using CoreDomain.Users;
using Microsoft.Data.SqlClient;
using SeniorConnect.Domain.Contracts;
using System.Net;

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

        public async Task SaveToDBAsync(User user)
        {
            string query = @"
                INSERT INTO [dbo].[Users] 
                ([FirstName], [LastName], [Email], [Password], [DateOfBirth], [Gender], [Origin], [DateOfRegistration], [StreetName], [HouseNumber], [Zipcode], [City], [Country]) 
                VALUES 
                (@FirstName, @LastName, @Email, @Password, @DateOfBirth, @Gender, @Origin, @DateOfRegistration, @StreetName, @HouseNumber, @Zipcode, @City, @Country)";

            try
            {
                using (var connection = await _dataAccess.OpenSqlConnection())
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", (object?)user.Gender ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Origin", (object?)user.Origin ?? DBNull.Value);
                    command.Parameters.AddWithValue("@DateOfRegistration", user.DateOfRegistration);
                    command.Parameters.AddWithValue("@Country", user.Country);
                    command.Parameters.AddWithValue("@StreetName", user.StreetName);
                    command.Parameters.AddWithValue("@HouseNumber", user.HouseNumber);
                    command.Parameters.AddWithValue("@Zipcode", user.Zipcode);
                    command.Parameters.AddWithValue("@City", user.City);
                    command.Parameters.AddWithValue("@Country", user.Country);

                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                LogError("Error saving user to database", ex);
                throw;
            }
        }

        //public async Task<List<User>> GetUsersAsync()
        //{
        //    var users = new List<User>();
        //    string query = @"SELECT [UserId], [FirstName], [LastName], [Email], [Password], [DateOfBirth], [Gender], [Origin], [DateOfRegistration], [AddressID]

        //             FROM [dbo].[Users]";

        //    try
        //    {
        //        using (var connection = await _dataAccess.OpenSqlConnection())
        //        using (var command = new SqlCommand(query, connection))
        //        using (var reader = await command.ExecuteReaderAsync())
        //        {
        //            while (await reader.ReadAsync())
        //            {
        //                var user = new User
        //                {
        //                    Id = reader.GetInt32(0),
        //                    FirstName = reader.GetString(1),
        //                    LastName = reader.GetString(2),
        //                    Email = reader.GetString(3),
        //                    Password = reader.GetString(4),
        //                    DateOfBirth = reader.IsDBNull(5) ? (DateOnly?)null : DateOnly.FromDateTime(reader.GetDateTime(5)),
        //                    Gender = reader.IsDBNull(6) ? (char?)null : reader.GetString(6)[0],
        //                    DateOfRegistration = reader.IsDBNull(7) ? default : DateOnly.FromDateTime(reader.GetDateTime(7))
        //                };

        //                users.Add(user);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Error loading data: " + ex.Message);
        //    }

        //    return users;
        //}


        //public async Task UpdateAsync(User user)
        //{
        //    var updateUserQuery = @"UPDATE [User] SET 
        //                    FirstName = @FirstName, 
        //                    LastName = @LastName, 
        //                    Email = @Email, 
        //                    Password = @Password, 
        //                    DateOfBirth = @DateOfBirth, 
        //                    Gender = @Gender, 
        //                    Origin = @Origin 
        //                    StreetName = @StreetName, 
        //                    HouseNumber = @HouseNumber, 
        //                    Zipcode = @Zipcode, 
        //                    City = @City, 
        //                    Country = @Country 
        //                    WHERE UserId = @UserId";

        //    try
        //    {
        //        using (var connection = await _dataAccess.OpenSqlConnection())
        //        using (var transaction = connection.BeginTransaction())
        //        {
        //            // Update User
        //            using (var userCommand = new SqlCommand(updateUserQuery, connection, transaction))
        //            {
        //                userCommand.Parameters.AddWithValue("@UserId", user.Id);
        //                userCommand.Parameters.AddWithValue("@FirstName", user.FirstName);
        //                userCommand.Parameters.AddWithValue("@LastName", user.LastName);
        //                userCommand.Parameters.AddWithValue("@Email", user.Email);
        //                userCommand.Parameters.AddWithValue("@Password", user.Password);
        //                userCommand.Parameters.AddWithValue("@DateOfBirth", (object?)user.DateOfBirth ?? DBNull.Value);
        //                userCommand.Parameters.AddWithValue("@Gender", (object?)user.Gender ?? DBNull.Value);
        //                userCommand.Parameters.AddWithValue("@Origin", (object?)user.Origin ?? DBNull.Value);
        //                userCommand.Parameters.AddWithValue("@StreetName", user.StreetName);
        //                userCommand.Parameters.AddWithValue("@HouseNumber", user.HouseNumber);
        //                userCommand.Parameters.AddWithValue("@Zipcode", user.Zipcode);
        //                userCommand.Parameters.AddWithValue("@City", user.City);
        //                userCommand.Parameters.AddWithValue("@Country", user.Country);

        //                await userCommand.ExecuteNonQueryAsync();
        //            }
        //            // Commit the transaction
        //            transaction.Commit();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogError("Error updating user and address to database", ex);
        //        throw;
        //    }
        //}


        //public bool IsDuplicateEmail(string email)
        //{
        //    return true;
        //    //     return Users.Any(u => u.Email == email);
        //}

        private void LogError(string message, Exception ex)
        {
            //change to handle error!!! + log it?
            Console.WriteLine($"{message}: {ex.Message}");
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
                        return new User
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Email = reader.GetString(3),
                            Password = reader.GetString(4),
                            DateOfBirth = reader.IsDBNull(5) ? (DateOnly?)null : DateOnly.FromDateTime(reader.GetDateTime(5)),
                            Gender = reader.GetString(6)[0],
                            Origin = reader.GetString(7),
                            DateOfBirth = reader.IsDBNull(8) ? (DateOnly?)null : DateOnly.FromDateTime(reader.GetDateTime(8)),
                            StreetName = reader.GetString(9), 
                            HouseNumber = reader.GetString(10),
                            Zipcode = reader.GetString(11),
                            City = reader.GetString(12),
                            Country = reader.GetString(13)
                        };
                    }
                }
            }

            return null; // Return null if no user found
        }


        //public Task <List<User>> GetAllAsync()
        //{
        //    throw new NotImplementedException();
        //}

        //public Task DeleteAsync(int id)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
