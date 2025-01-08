using SeniorConnect.Domain;

namespace SeniorConnect.Application.Interfaces;
public interface IActivityRepository
{
    public Task SaveActivityToDBAsync(Activity activity);

    public Task<Activity?> GetActivityByIdAsync(int activityId);

    public Task<List<Activity>> GetAllActivitiesAsync();

    public Task<bool> UpdateActivityAsync(Activity activity);

    public Task<bool> DeleteActivityAsync(int activityId);
}
