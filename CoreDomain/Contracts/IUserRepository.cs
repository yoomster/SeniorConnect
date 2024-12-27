using CoreDomain;
using CoreDomain.Users;

namespace SeniorConnect.Domain.Contracts;

public interface IUserRepository
{
    public Task<int> SaveToDBAsync(User user);

    public Task<User?> GetByIdAsync(int id);

    public Task<List<User>> GetAllAsync();

    public Task<bool> UpdateAsync(User user);

    public Task<bool> DeleteAsync(int userId);
}