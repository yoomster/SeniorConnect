using SeniorConnect.Domain;

namespace SeniorConnect.Application.Interfaces;

public interface IUserRepository
{
    Task CreateUserAsync(User user);

    Task<User?> GetByEmailAsync(string email);

    Task<User?> GetByIdAsync(int id);

    Task<IEnumerable<User>> GetAllAsync();

    Task<bool> UpdateAccountAsync(User user);

    Task<bool> DeleteByIdAsync(int userId);

    Task<bool> IsEmailDuplicate(string email);

}
