using CoreDomain;
using CoreDomain.Users;
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

        public async Task SaveUserToDBAsync(User user)
        {
            string query = @"
                INSERT INTO [dbo].[User] 
                ([FirstName], [LastName], [Email], [Password], [DateOfBirth], [Gender], [Origin], [DateOfRegistration], [AddressID]) 
                VALUES 
                (@FirstName, @LastName, @Email, @Password, @DateOfBirth, @Gender, @Origin, @DateOfRegistration, @AddressID)";

            try
            {
                using (var connection = await _dataAccess.OpenSqlConnection())
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Password", HashPassword(user.Password));
                    command.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", (object?)user.Gender ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Origin", (object?)user.Origin ?? DBNull.Value);
                    command.Parameters.AddWithValue("@DateOfRegistration", user.DateOfRegistration);
                    command.Parameters.AddWithValue("@AddressID", user.AddressId);

                    await command.ExecuteNonQueryAsync();
                }
            }
            catch (Exception ex)
            {
                LogError("Error saving user to database", ex);
                throw;
            }
        }

        private void LogError(string message, Exception ex)
        {
            //change to handle error!!! + log it?
            Console.WriteLine($"{message}: {ex.Message}");
        }

        public async Task<List<User>> GetUsersAsync()
        {
            var users = new List<User>();
            string query = @"SELECT [UserId], [FirstName], [LastName], [Email], [Password], [DateOfBirth], [Gender], [Iban], [DateOfRegistration], 
                     [StreetName], [HouseNumber], [Zipcode], [City], [Country] 
                     FROM [dbo].[User]";

            try
            {
                using (var connection = await _dataAccess.OpenSqlConnection())
                using (var command = new SqlCommand(query, connection))
                using (var reader = await command.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var user = new User
                        {
                            Id = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Email = reader.GetString(3),
                            Password = reader.GetString(4),
                            DateOfBirth = reader.IsDBNull(5) ? (DateOnly?)null : DateOnly.FromDateTime(reader.GetDateTime(5)),
                            Gender = reader.IsDBNull(6) ? (char?)null : reader.GetString(6)[0],
                            DateOfRegistration = reader.IsDBNull(7) ? default : DateOnly.FromDateTime(reader.GetDateTime(7))
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


        public async Task UpdateUserAsync(User user, Address address)
        {
            var updateUserQuery = @"UPDATE [User] SET 
                            FirstName = @FirstName, 
                            LastName = @LastName, 
                            Email = @Email, 
                            Password = @Password, 
                            DateOfBirth = @DateOfBirth, 
                            Gender = @Gender, 
                            Iban = @Iban 
                            WHERE UserId = @UserId";

            var updateAddressQuery = @"UPDATE [Address] SET 
                               StreetName = @StreetName, 
                               HouseNumber = @HouseNumber, 
                               Zipcode = @Zipcode, 
                               City = @City, 
                               Country = @Country 
                               WHERE AddressId = @AddressId";

            try
            {
                using (var connection = await _dataAccess.OpenSqlConnection())
                using (var transaction = connection.BeginTransaction())
                {
                    // Update User
                    using (var userCommand = new SqlCommand(updateUserQuery, connection, transaction))
                    {
                        userCommand.Parameters.AddWithValue("@UserId", user.Id);
                        userCommand.Parameters.AddWithValue("@FirstName", user.FirstName);
                        userCommand.Parameters.AddWithValue("@LastName", user.LastName);
                        userCommand.Parameters.AddWithValue("@Email", user.Email);
                        userCommand.Parameters.AddWithValue("@Password", HashPassword(user.Password));
                        userCommand.Parameters.AddWithValue("@DateOfBirth", (object?)user.DateOfBirth ?? DBNull.Value);
                        userCommand.Parameters.AddWithValue("@Gender", (object?)user.Gender ?? DBNull.Value);

                        await userCommand.ExecuteNonQueryAsync();
                    }

                    // Update Address
                    using (var addressCommand = new SqlCommand(updateAddressQuery, connection, transaction))
                    {
                        addressCommand.Parameters.AddWithValue("@AddressId", address.Id);
                        addressCommand.Parameters.AddWithValue("@StreetName", address.StreetName);
                        addressCommand.Parameters.AddWithValue("@HouseNumber", address.HouseNumber);
                        addressCommand.Parameters.AddWithValue("@Zipcode", address.Zipcode);
                        addressCommand.Parameters.AddWithValue("@City", address.City);
                        addressCommand.Parameters.AddWithValue("@Country", address.Country);

                        await addressCommand.ExecuteNonQueryAsync();
                    }

                    // Commit the transaction
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                LogError("Error updating user and address to database", ex);
                throw;
            }
        }


        bool IUserRepository.IsDuplicateEmail(string email)
        {
            return true;
            //     return Users.Any(u => u.Email == email);
        }

        public async Task UpdateUser(User user)
        {
            string query = @"UPDATE [SeniorConnect.SQLServerDB].[dbo].[User] SET 
                [FirstName] = @FirstName,
                [LastName] = @LastName,
                [Email] = @Email,
                [Password] = @Password,
                [DateOfBirth] = @DateOfBirth,
                [Gender] = @Gender,
                [Iban] = @Iban,
                [DateOfRegistration] = @DateOfRegistration
            WHERE [Id] = @Id";

            try
            {
                using (var connection = await _dataAccess.OpenSqlConnection())
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Id", user.Id);
                    command.Parameters.AddWithValue("@FirstName", user.FirstName);
                    command.Parameters.AddWithValue("@LastName", user.LastName);
                    command.Parameters.AddWithValue("@Email", user.Email);
                    command.Parameters.AddWithValue("@Password", HashPassword(user.Password));
                    command.Parameters.AddWithValue("@DateOfBirth", (object?)user.DateOfBirth ?? DBNull.Value);
                    command.Parameters.AddWithValue("@Gender", (object?)user.Gender ?? DBNull.Value);
                    command.Parameters.AddWithValue("@DateOfRegistration", user.DateOfRegistration);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // DEAL WITH THE EXCEPTION
                Console.WriteLine("Error updating data: " + ex.Message);
                throw; // Rethrow exception for higher-level handling if needed
            }
        }

        private string HashPassword(string password)
        {
            //impl. hashing logic
            return password;
        }


    }
}
