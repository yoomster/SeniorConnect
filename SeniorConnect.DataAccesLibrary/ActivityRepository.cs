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

        //public void SaveActivityToDB(Activity activity)
        //{
        //    string query = "";

        //    try
        //    {
        //        using (var connection = _dataAccess.OpenSqlConnection())
        //        using (var command = new SqlCommand(query, connection))
        //        {
        //            command.Parameters.AddWithValue("@Name", activity.Na);

        //            command.ExecuteNonQuery();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
    }
}
