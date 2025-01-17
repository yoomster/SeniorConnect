using SeniorConnect.Application.Interfaces;
using SeniorConnect.Domain;

namespace SeniorConnect.Application.Services
{
    public class ActivityService : IRegistrationValidator
    {
        private readonly IActivityRepository _activityRepository;

        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }
        public Task<bool> CanRegister(User user)
        {
            //check if user is not already signed up
            throw new NotImplementedException();
        }

        public async Task CreateActivity(Activity activity)
        {
            Activity newActivity = new(
                title: activity.Title,
                description: activity.Description,
                date: activity.Date,
                startTime: activity.StartTime,
                endTime: activity.EndTime,
                maxParticipants: activity.MaxParticipants,
                streetName: activity.StreetName,
                houseNumber: activity.HouseNumber,
                zipcode: activity.Zipcode,
                city: activity.City,
                country: activity.Country
                );

            await _activityRepository.CreateActivityAsync(newActivity);
        }

        public async Task<Activity?> GetActivityById(int id)
        {
            return await _activityRepository.GetActivityByIdAsync(id);
        }

        public async Task<IEnumerable<Activity>> GetAllAsync()
        {
            return await _activityRepository.GetAllAsync();
        }

        public async Task ChangeActivity(Activity activity)
        {
            Activity changedActivity = new(
                id: activity.Id,
                title: activity.Title,
                description: activity.Description,
                date: activity.Date,
                startTime: activity.StartTime,
                endTime: activity.EndTime,
                maxParticipants: activity.MaxParticipants,
                streetName: activity.StreetName,
                houseNumber: activity.HouseNumber,
                zipcode: activity.Zipcode,
                city: activity.City,
                country: activity.Country);

            await _activityRepository.UpdateActivityAsync(changedActivity);
        }

        public async Task DeleteActivity(int activityId)
        {
            await _activityRepository.DeleteByIdAsync(activityId);
        }

        public static List<User> GetParticipants(int activityId)
        {
            throw new NotImplementedException();
        }



        //An activity cannot contain more than the maximum number of participants
    }
}
