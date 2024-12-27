using CoreDomain;
using CoreDomain.Users;

namespace SeniorConnect.Domain.Contracts;

public interface IUserRepository
{
    public Task<int> SaveUserToDBAsync(User user);

    public Task<User?> GetUserByIdAsync(int id);

    public Task<List<User>> GetUserAllAsync();

    public Task<bool> UpdateUserAsync(User user);

    public Task<bool> DeleteUserAsync(int userId);
}