using SeniorConnect.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorConnect.Domain.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public static void CreateUser(object user)
        {
            throw new NotImplementedException();
            //if statement for validation, if true, create
        }

        //hashing van het wachtwoord?
        private string HashPassword(string password)
        {
            //impl. hashing logic
            return password;
        }
    }
}
