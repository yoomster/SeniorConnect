using SeniorConnect.Domain;

namespace SeniorConnect.Application.Interfaces;

public interface IUserRepository
{
    Task CreateUserInDBAsync(User user);

    Task<User?> GetByEmailAsync(string email);

    Task<List<User>> GetAllAsync();

    Task<bool> UpdateAccountAsync(User user);

    Task<bool> DeleteAccountAsync(int userId);

    Task<User> ValidateUserAsync(string email, string password);

    //public Task<bool> IsEmailRegistered(string email);
}
