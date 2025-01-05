using CoreDomain;
using SeniorConnect.Domain;

namespace SeniorConnect.Application.Interfaces;

public interface IUserRepository
{
    public Task<int> SaveUserToDBAsync(User user);

    public Task<User?> GetByIdAsync(int id);

    public Task<List<User>> GetAllUserAsync();

    public Task<bool> UpdateUserAsync(User user);

    public Task<bool> DeleteUserAsync(int userId);

    public Task<bool> IsDuplicateEmailAsync(string email);

}