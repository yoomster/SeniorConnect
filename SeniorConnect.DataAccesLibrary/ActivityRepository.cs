using Microsoft.Data.SqlClient;
using SeniorConnect.Application.Interfaces;
using SeniorConnect.Domain;
using System.Data;

namespace SeniorConnect.DataAccesLibrary
{
    internal class ActivityRepository : IActivityRepository
    {
        private readonly DataAccess _dataAccess;

        public ActivityRepository(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task CreateActivityAsync(Activity activity)
        {
            string query = @"
                INSERT INTO [dbo].[Activities] 
                ([Name], [Description], [Date], [StartTime], [EndTime], [MaxParticipants], [StreetName], [HouseNumber], [Zipcode], [City], [Country]) 
                VALUES 
                (@Name, @Description, @Date, @StartTime, @EndTime, @MaxParticipants, @StreetName, @HouseNumber, @Zipcode, @City, @Country);
                SELECT CAST(SCOPE_IDENTITY() AS INT);"; //gets new ActivityId

            using (var connection = await _dataAccess.OpenSqlConnection())
            using (var command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Title", activity.Title);
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
                command.Parameters.AddWithValue("@HostUserId", activity.HostUserId);


                var result = await command.ExecuteScalarAsync();
            }
        }

        public async Task<List<Activity>> GetAllAsync()
        {
            string query = @"SELECT 
                    [ActivityId], [Title], [Description], [Date], [StartTime], [EndTime], [MaxParticipants], 
                    [StreetName], [HouseNumber], [Zipcode], [City], [Country], [hostUserId] 
                     FROM [dbo].[Activities]";

            var activities = new List<Activity>();

            using (var connection = await _dataAccess.OpenSqlConnection())
            using (var command = new SqlCommand(query, connection))
            using (var reader = await command.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                {
                    activities.Add(new Activity(
                        id: reader.GetInt32(0),
                        title: reader.GetString(1),
                        description: reader.GetString(2),
                        date: DateOnly.FromDateTime(reader.GetDateTime(3)),  
                        startTime: TimeOnly.FromTimeSpan(reader.GetTimeSpan(4)),
                        endTime: TimeOnly.FromTimeSpan(reader.GetTimeSpan(5)),
                        maxParticipants: reader.GetInt32(6),
                        streetName: reader.GetString(7),
                        houseNumber: reader.GetString(8),
                        zipcode: reader.GetString(9),
                        city: reader.GetString(10),
                        country: reader.GetString(11),
                        hostUserId: reader.GetInt32(12)
                        ) );
                }
            }

            return activities;
        }

        public async Task<Activity?> GetActivityByIdAsync(int activityId)
        {
            string query = @"SELECT                     
                    [ActivityId], [Title], [Description], [Date], [StartTime], [EndTime], [MaxParticipants], 
                    [StreetName], [HouseNumber], [Zipcode], [City], [Country], [hostUserId] 
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
                        return new Activity(
                        id: reader.GetInt32(0),
                        title: reader.GetString(1),
                        description: reader.GetString(2),
                        date: DateOnly.FromDateTime(reader.GetDateTime(3)),
                        startTime: TimeOnly.FromDateTime(reader.GetDateTime(4)),
                        endTime: TimeOnly.FromDateTime(reader.GetDateTime(5)),
                        maxParticipants: reader.GetInt32(6),
                        streetName: reader.GetString(7),
                        houseNumber: reader.GetString(8),
                        zipcode: reader.GetString(9),
                        city: reader.GetString(10),
                        country: reader.GetString(11),
                        hostUserId: reader.GetInt32(12)
                        );
                    }
                }
            }

            return null;
        }

        public async Task<bool> UpdateActivityAsync(Activity activity)
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

        public async Task<bool> DeleteActivityAsync(int activityId)
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
