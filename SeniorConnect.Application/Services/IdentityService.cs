using SeniorConnect.Application.Interfaces;
using SeniorConnect.Domain;

namespace SeniorConnect.Application.Services
{
    public class IdentityService
    {
        private readonly IUserRepository _userRepository;

        public IdentityService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task CreateAccount(User user)
        {
            if (await _userRepository.IsDuplicateEmailAsync(user.Email))
            {
                throw new InvalidOperationException("Email is already registered.");
            }
            else
            {
                //var hash = HashPassword(user.Password, out var salt);

                User newUser = new User
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    Password = user.Password,
                    DateOfBirth = user.DateOfBirth,
                    Gender = user.Gender,
                    Origin = user.Origin,
                    Interests = user.Interests,
                    DateOfRegistration = DateOnly.FromDateTime(DateTime.Now),
                    StreetName = user.StreetName,
                    HouseNumber = user.HouseNumber,
                    Zipcode = user.Zipcode,
                    City = user.City,
                    Country = user.Country,
                };

                await _userRepository.CreateAccountToDBAsync(newUser);
            }
        }
        
        public void Login(string email, string password)
        {

        }

        public void Logout()
        {

        }

        public void DeleteAccount(int userId)
        {
            _userRepository.DeleteAccountAsync(userId);


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
