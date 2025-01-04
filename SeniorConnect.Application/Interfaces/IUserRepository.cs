using CoreDomain;
using CoreDomain.Users;

namespace SeniorConnect.Application.Interfaces;

public interface IUserRepository
{
    public Task<int> SaveUserToDBAsync(User user);

    public Task<User?> GetUserByIdAsync(int id);

    public Task<List<User>> GetAllUserAsync();

    public Task<bool> UpdateUserAsync(User user);

    public Task<bool> DeleteUserAsync(int userId);

    public Task<bool> IsDuplicateEmailAsync(string email);

}