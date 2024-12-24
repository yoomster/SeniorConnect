using CoreDomain;
using CoreDomain.Users;

namespace SeniorConnect.Domain.Contracts;

public interface IActivityRepository
{
    Task SaveToDBAsync(Object activity);
    Task GetByIdAsync(int id);
    Task<List<Object>> GetAllAsync();
    Task UpdateAsync(Object activity, Object address);
    Task DeleteAsync(int id);
}

