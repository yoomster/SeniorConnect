using SeniorConnect.Application.Interfaces;
using SeniorConnect.Domain;

namespace SeniorConnect.Application.Services
{
    public class ActivityService
    {
        private readonly IActivityRepository _activityRepository;

        public ActivityService(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task CreateActivity(Activity activity, int loggedInUserId)
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

            newActivity.AssignHostUser(loggedInUserId);

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
                country: activity.Country,
                hostUserId: activity.HostUserId);

            await _activityRepository.UpdateActivityAsync(changedActivity);
        }

        public async Task DeleteActivity(int activityId)
        {
            await _activityRepository.DeleteActivityAsync(activityId);
        }

        public static List<User> GetParticipants(int activityId)
        {
            throw new NotImplementedException();
        }

        //An activity cannot contain more than the maximum number of participants
    }
}
