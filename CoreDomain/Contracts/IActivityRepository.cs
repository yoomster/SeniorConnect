using SeniorConnect.Domain.Activities;

namespace SeniorConnect.Domain.Contracts;

public interface IActivityRepository
{
    public Task SaveActivityToDBAsync(Activity activity);

    public Task<Activity?> GetActivityByIdAsync(int activityId);

    public Task<List<Activity>> GetAllActivitiesAsync();

    public Task<bool> UpdateActivityAsync(Activity activity);

    public Task<bool> DeleteActivityAsync(int activityId);

}

