using CoreDomain;
using CoreDomain.Users;

namespace SeniorConnect.Domain.Contracts;

public interface IAddressRepository
{
    Task SaveToDBAsync(object address);
    Task GetByIdAsync(int id);
    Task<List<User>> GetAllAsync();
    Task UpdateAsync(Object address);
    Task DeleteAsync(int id);
}


