using CoreDomain.Users;
using CoreDomain;
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

        public static async Task AddUser(User user)
        {
            var newUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Password = user.Password,
                DateOfBirth = user.DateOfBirth,
                Gender = user.Gender,
                Origin = user.Origin,
                DateOfRegistration = DateOnly.FromDateTime(DateTime.Now),
                StreetName = user.StreetName,
                HouseNumber = user.HouseNumber,
                Zipcode = user.Zipcode,
                City = user.City,
                Country = user.Country,
            };

            await _userRepository.SaveToDBAsync(newUser);

            //if statement for validation, if true, create
        }

        //hashing van het wachtwoord?
        private string HashPassword(string password)
        {
            //impl. hashing logic
            return password;
        }

        private bool isEmailUnique(string email)
        {
            bool output = false;

            if (true)
            {

            }

            return output;
        }
    }
}
