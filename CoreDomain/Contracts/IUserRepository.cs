using CoreDomain.Users;

namespace SeniorConnect.Domain.Contracts;

public interface IUserRepository
{
    public Task SaveUserToDBAsync(User user);
    public Task<List<User>> GetUsersAsync();
    public bool IsDuplicateEmail(string email);
    public Task UpdateUserAsync(User user);
}

