using SeniorConnect.Domain;

namespace SeniorConnect.Application.Interfaces;

public interface IUserRepository
{
    Task CreateUserAsync(User user);

    Task<User?> GetByEmailAsync(string email);

    Task<List<User>> GetAllAsync();

    Task<bool> UpdateAccountAsync(User user);

    Task<bool> DeleteAccountAsync(int userId);

    //public Task<bool> IsEmailRegistered(string email);
}
