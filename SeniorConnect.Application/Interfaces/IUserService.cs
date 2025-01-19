using SeniorConnect.Application.Utilities;
using SeniorConnect.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorConnect.Application.Interfaces
{
    internal interface IUserService
    {
        Task<ValidationResult> CreateAccount(User user);
        
        Task<IEnumerable<User>> GetAllAsync();

       Task<User> GetById(int id);

       Task<User> GetByEmail(string email);

        Task DeleteAccount(int userId);
    }
}
