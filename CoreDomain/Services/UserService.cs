using CoreDomain.Users;
using CoreDomain;
using SeniorConnect.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SeniorConnect.Domain.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddUser(User user)
        {

            if (IsEmailUnique(user.Email))
            {
                var hash = HashPassword(user.Password, out var salt);

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
            }

        }

        //hashing van het wachtwoord?
        private static string HashPassword(string password, out byte[] salt)
        {
            const int keySize = 64;
            const int iterations = 350000;
            HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

            salt = RandomNumberGenerator.GetBytes(keySize);

            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                hashAlgorithm,
                keySize);

            return Convert.ToHexString(hash);
        }

        private static bool IsEmailUnique(string email)
        {
            bool output = false;

            if (true)
            {

            }

            return output;
        }


    }
}
