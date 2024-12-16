using CoreDomain;
using CoreDomain.Users;

namespace SeniorConnect.Domain.Contracts;

public interface IAddressRepository
{
    public Task<int> SaveAddressToDBAsync(Address address);
    public Task UpdateAddresssync(Address address);
}


