using CoreDomain.Users;
using Microsoft.Data.SqlClient;
using SeniorConnect.Domain.Activity;

namespace SeniorConnect.DataAccesLibrary
{
    public class ActivityRepository
    {
        private readonly DataAccess _dataAccess;

        public ActivityRepository(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public void SaveActivityToDB(Activity activity)
        {
            string query = "INSERT INTO Activities (Name, Description, Date, StartTime, EndTime, MaxParticipants, CoordinatorId, LocationId) " +
                            "VALUES (@Name, @Description, @Date, @StartTime, @EndTime, @MaxParticipants, @CoordinatorId, @LocationId)";

            try
            {
                using (var connection = _dataAccess.OpenSqlConnection())
                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", activity.Name); // Note: Ensure you have a public getter for Name
                    command.Parameters.AddWithValue("@Description", activity.Description);
                    command.Parameters.AddWithValue("@Date", activity.Date);
                    command.Parameters.AddWithValue("@StartTime", activity.StartTime);
                    command.Parameters.AddWithValue("@EndTime", activity.EndTime);
                    command.Parameters.AddWithValue("@MaxParticipants", activity.MaxParticipants);
                    command.Parameters.AddWithValue("@CoordinatorId", activity.ActivityCoordinatorId);
                    command.Parameters.AddWithValue("@LocationId", activity.LocationId);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                //DEAL WITH THIS!
                throw new Exception("Error saving activity to DB", ex);
            }
        }


        public List<Activity> GetActivities()
        {
            List<Activity> activities = new List<Activity>();

            string query = "SELECT [Id], [Name], [Description], [Date], [StartTime], [EndTime], [MaxParticipants], [CoordinatorId], [LocationId] FROM [Activity]";
            try
            {
                using (var connection = _dataAccess.OpenSqlConnection())
                using (var command = new SqlCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var activity = new Activity(
                            id: reader.GetInt32(0),
                            name: reader.GetString(reader.GetOrdinal("Name")),
                            description: reader.GetString(reader.GetOrdinal("Description")),
                            date: DateOnly.Parse(reader.GetString(reader.GetOrdinal("Date"))),  //  Date is in string format?
                            startTime: TimeOnly.Parse(reader.GetString(reader.GetOrdinal("StartTime"))),    //  StartTime is in string format?
                            endTime: TimeOnly.Parse(reader.GetString(reader.GetOrdinal("EndTime"))),        //  EndTime is in string format?
                            maxParticipants: reader.GetInt32(reader.GetOrdinal("MaxParticipants"))
                        )
                        {
                            
                        };

                        activities.Add(activity);
                    }
                }
            }
            catch (Exception ex)
            {
                //DEAL WITH THIS!
                Console.WriteLine("Error loading data: " + ex.Message);
            }

            return activities;
        }
    }
}
