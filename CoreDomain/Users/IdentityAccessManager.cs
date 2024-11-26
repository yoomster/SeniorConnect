using CoreDomain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SeniorConnect.Domain.Users
{
    public class IdentityAccessManager
    {
        //private readonly UserRegistration _userRegistration;

        //public IdentityAccessManager(UserRegistration userRegistration)
        //{
        //    _userRegistration = userRegistration;
        //}

        // THIS LAYER NEEDS TO KNOW ABOUT UI!!!!

        public User CreateUser()
        {
            User output = new()
            {
                FirstName = string.Empty,
                LastName = string.Empty,
                Email = string.Empty,
                Password = string.Empty,
                DateOfBirth = DateOnly.FromDateTime(DateTime.Now),
                Gender = 'M',
                DateOfRegistration = DateOnly.FromDateTime(DateTime.Now),

            };

            return output;
        }
    }
}
