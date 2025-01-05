using SeniorConnect.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorConnect.Application.Interfaces
{
    public interface IRegistrationRepository
    {
        public Task SaveRegistrationToDBAsync(ActivityRegistration registration);
        public Task<List<User>> GetAllUsersOfActivityAsync();

    }
}
