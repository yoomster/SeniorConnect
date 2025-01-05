using SeniorConnect.Application.Interfaces;
using SeniorConnect.Domain;

namespace SeniorConnect.Application.Services
{
    public class UserService
    {
        public async Task CreateUser(User user)
        {
            if (await IUserRepository.IsDuplicateEmailAsync(user.Email))
            {
                throw new InvalidOperationException("Email is already registered.");
            }
            else
            {
                //var hash = HashPassword(user.Password, out var salt);

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

                await _userRepository.SaveUserToDBAsync(newUser);
            }
        }
        //private static /*string*/ void HashPassword(string password, out byte[] salt)
        //{
            //    const int keySize = 64;
            //    const int iterations = 350000;
            //    HashAlgorithmName hashAlgorithm = HashAlgorithmName.SHA512;

            //    salt = RandomNumberGenerator.GetBytes(keySize);

            //    var hash = Rfc2898DeriveBytes.Pbkdf2(
            //        Encoding.UTF8.GetBytes(password),
            //        salt,
            //        iterations,
            //        hashAlgorithm,
            //        keySize);

            //    return Convert.ToHexString(hash);
        //}
    }
}
