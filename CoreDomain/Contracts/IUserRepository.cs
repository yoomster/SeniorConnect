using CoreDomain.Users;

namespace SeniorConnect.Domain.Contracts;

public interface IUserRepository
{
    public void SaveUserToDB(User user);
    public List<User> GetUsers();

    public bool IsDuplicateEmail(string email);
}
