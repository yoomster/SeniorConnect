using CoreDomain;
using CoreDomain.Users;

namespace SeniorConnect.Domain.Contracts;

public interface IActivityRepository
{
    Task AddAsync(Activity activity);
    Task<Activity> GetByIdAsync(int id);
    Task<IEnumerable<Activity>> GetAllAsync();
}

