using CoreDomain;
using CoreDomain.Users;

namespace SeniorConnect.Domain.Contracts;

public interface IUserRepository
{
    Task SaveToDBAsync(User user);
    Task GetByIdAsync(int id);
    //Task <List<User>> GetAllAsync();
    //Task UpdateAsync(User user);
    //Task DeleteAsync(int id);
}