using SeniorConnect.Domain;
using SeniorConnect.WebApp.Models;
using System.Runtime.CompilerServices;

namespace SeniorConnect.WebApp.Mapping
{
    public static class ActivityMapping
    {
        public static Activity ToActivityEntity(this ActivityFormModel formModel)
        {
            return new Activity(
                formModel.Title,
                formModel.Description,
                formModel.Date,
                formModel.StartTime,
                formModel.EndTime,
                formModel.MaxParticipants,
                formModel.StreetName,
                formModel.HouseNumber,
                formModel.Zipcode,
                formModel.Country,
                formModel.Country
                );
        }
    }
}
