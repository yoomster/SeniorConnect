using SeniorConnect.Domain;

namespace SeniorConnect.Application.Interfaces;
public interface IActivityRepository
{
    Task CreateActivityAsync(Activity activity);

    Task<Activity?> GetActivityByIdAsync(int activityId);

    Task<IEnumerable <Activity>> GetAllAsync();

    Task<bool> UpdateActivityAsync(Activity activity);

    Task<bool> DeleteByIdAsync(int activityId);
}
