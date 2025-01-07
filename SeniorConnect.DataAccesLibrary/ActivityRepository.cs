using Microsoft.Data.SqlClient;
using SeniorConnect.Domain;

namespace SeniorConnect.DataAccesLibrary
{
    internal class ActivityRepository
    {
        //MAKE ALL METHOD INTERNAL, NO DI ALLOWED TO UI LAYER!

        private readonly DataAccess _dataAccess;

        internal ActivityRepository(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task SaveActivityToDBAsync(Activity activity)
        {
            string query = @"INSERT INTO [dbo].[Activities] 
                     ([Name], [Description], [Date], [StartTime], [EndTime], [MaxParticipants], [StreetName], [HouseNumber], [Zipcode], [City], [Country]) 
                     VALUES 
                     (@Name, @Description, @Date, @StartTime, @EndTime, @MaxParticipants, @StreetName, @HouseNumber, @Zipcode, @City, @Country);
                     SELECT SCOPE_IDENTITY();"; // To get the newly inserted ActivityId

            using (var connection = await _dataAccess.OpenSqlConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Name", activity.Title);
                command.Parameters.AddWithValue("@Description", activity.Description); 
                command.Parameters.AddWithValue("@Date", activity.Date);
                command.Parameters.AddWithValue("@StartTime", activity.StartTime);
                command.Parameters.AddWithValue("@EndTime", activity.EndTime);
                command.Parameters.AddWithValue("@MaxParticipants", activity.MaxParticipants);
                command.Parameters.AddWithValue("@StreetName", activity.StreetName);
                command.Parameters.AddWithValue("@HouseNumber", activity.HouseNumber);
                command.Parameters.AddWithValue("@Zipcode", activity.Zipcode);
                command.Parameters.AddWithValue("@City", activity.City);
                command.Parameters.AddWithValue("@Country", activity.Country);

                var result = await command.ExecuteScalarAsync();
            }
        }

        public async Task<Activity?> GetByIdAsync(int activityId)
        {
            string query = @"SELECT [ActivityId], [Name], [Description], [Date], [StartTime], [EndTime], [MaxParticipants], 
                            [StreetName], [HouseNumber], [Zipcode], [City], [Country]  
                     FROM [dbo].[Activities] 
                     WHERE [ActivityId] = @ActivityId";

            using (var connection = await _dataAccess.OpenSqlConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ActivityId", activityId);

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        return new Activity(1)
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Description = reader.GetString(2),
                            Date = DateOnly.FromDateTime(reader.GetDateTime(3)),
                            StartTime = TimeOnly.FromDateTime(reader.GetDateTime(4)),
                            EndTime = TimeOnly.FromDateTime(reader.GetDateTime(5)),
                            MaxParticipants = reader.GetInt32(6),
                            StreetName = reader.GetString(7),
                            HouseNumber = reader.GetString(8),
                            Zipcode = reader.GetString(9),
                            City = reader.GetString(10),
                            Country = reader.GetString(11)
                        };
                    }
                }
            }

            return null; 
        }

        public async Task<List<Activity>> GetAllAsync()
        {
            string query = @"SELECT [ActivityId], [Name], [Description], [Date], [StartTime], [EndTime], 
                            [MaxParticipants], [StreetName], [HouseNumber], [Zipcode], [City], [Country]  
                     FROM [dbo].[Activities]";

            var activities = new List<Activity>();

            using (var connection = await _dataAccess.OpenSqlConnection())
            using (var command = new SqlCommand(query, connection))
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    activities.Add(new Activity
                    {
                        Id = reader.GetInt32(0),
                        Title = reader.GetString(1),
                        Description = reader.GetString(2),
                        Date = DateOnly.FromDateTime(reader.GetDateTime(3)),
                        StartTime = TimeOnly.FromDateTime(reader.GetDateTime(4)),
                        EndTime = TimeOnly.FromDateTime(reader.GetDateTime(5)),
                        MaxParticipants = reader.GetInt32(6),
                        StreetName = reader.GetString(7),
                        HouseNumber = reader.GetString(8),
                        Zipcode = reader.GetString(9),
                        City = reader.GetString(10),
                        Country = reader.GetString(11)
                    });
                }
            }

            return activities;
        }

        public async Task<bool> UpdateAsync(Activity activity)
        {
            string query = @"UPDATE [dbo].[Activities] 
                     SET [Name] = @Name, 
                         [Description] = @Description, 
                         [Date] = @Date, 
                         [StartTime] = @StartTime, 
                         [EndTime] = @EndTime, 
                         [MaxParticipants] = @MaxParticipants, 
                         [StreetName] = @StreetName, 
                         [HouseNumber] = @HouseNumber, 
                         [Zipcode] = @Zipcode, 
                         [City] = @City, 
                         [Country] = @Country 
                     WHERE [ActivityId] = @ActivityId";

            using (var connection = await _dataAccess.OpenSqlConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ActivityId", activity.Id);
                command.Parameters.AddWithValue("@Name", activity.Title);
                command.Parameters.AddWithValue("@Description", activity.Description);
                command.Parameters.AddWithValue("@Date", activity.Date);
                command.Parameters.AddWithValue("@StartTime", activity.StartTime);
                command.Parameters.AddWithValue("@EndTime", activity.EndTime);
                command.Parameters.AddWithValue("@MaxParticipants", activity.MaxParticipants);
                command.Parameters.AddWithValue("@StreetName", activity.StreetName);
                command.Parameters.AddWithValue("@HouseNumber", activity.HouseNumber);
                command.Parameters.AddWithValue("@Zipcode", activity.Zipcode);
                command.Parameters.AddWithValue("@City", activity.City);
                command.Parameters.AddWithValue("@Country", activity.Country);

                int rowsAffected = await command.ExecuteNonQueryAsync();
                return rowsAffected > 0; 
            }
        }

        public async Task<bool> DeleteAsync(int activityId)
        {
            string query = @"DELETE FROM [dbo].[Activities] 
                     WHERE [ActivityId] = @ActivityId";

            using (var connection = await _dataAccess.OpenSqlConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ActivityId", activityId);

                int rowsAffected = await command.ExecuteNonQueryAsync();
                return rowsAffected > 0; // Return true if deleted
            }
        }


    }
}
