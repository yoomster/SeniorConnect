using SeniorConnect.Application.Interfaces;
using SeniorConnect.Domain;

namespace SeniorConnect.Application.Services
{
    public class IdentityService 
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public IdentityService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
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
                //var hashedPassword = _passwordHasher.HashPassword(password, out var salt));

                User newUser = new User(
                    firstName: firstName,
                    lastName: lastName,
                    email: email,
                    password: password, //becomes hashedPassword after impl hashing methods
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
    }
}
