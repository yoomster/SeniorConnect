using CoreDomain;
using CoreDomain.Users;

namespace SeniorConnect.Domain.Contracts;

public interface IUserRepository
{
    Task SaveToDBAsync(object user);
    Task GetByIdAsync(int id);
    Task<List<User>> GetAllAsync();
    Task UpdateAsync(Object user, Object address);
    Task DeleteAsync(int id);
}