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
        public async Task CreateAccount(
            string firstName, string lastName, string email, 
            string password, DateOnly dateOfBirth, char gender,
            string origin, string maritalStatus, string streetName, 
            string houseNumber, string zipcode, string city, string country)
        {
            if (await _userRepository.IsEmailRegistered(email))
            {
                throw new InvalidOperationException("Email is already registered.");
            }
            else
            {
                //var hash = HashPassword(password, out var salt);

                User newUser = new User(
                    firstName: firstName,
                    lastName: lastName,
                    email: email,
                    password: password,
                    dateOfBirth: dateOfBirth,
                    gender: gender,
                    origin: origin,
                    maritalStatus: maritalStatus,
                    streetName: streetName,
                    houseNumber: houseNumber,
                    zipcode: zipcode,
                    city: city,
                    country: country
                );

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
