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
            //string firstName, string lastName, string email, 
            //string password, DateOnly dateOfBirth, char gender,
            //string origin, string maritalStatus, string streetName, 
            //string houseNumber, string zipcode, string city, string country
            User user)
        {
            if (await _userRepository.IsEmailRegistered(user.Email))
            {
                throw new InvalidOperationException("Email is already registered.");
            }
            else
            {
                //var hashedPassword = _passwordHasher.HashPassword(user.Password, out var salt));

                User newUser = new User(
                    firstName: user.FirstName,
                    lastName: user.LastName,
                    email: user.Email,
                    password: user.Password, //becomes hashedPassword after impl hashing methods ^^
                    dateOfBirth: user.DateOfBirth,
                    gender: user.Gender,
                    origin: user.Origin,
                    maritalStatus: user.MaritalStatus,
                    streetName: user.StreetName,
                    houseNumber: user.HouseNumber,
                    zipcode: user.Zipcode,
                    city: user.City,
                    country: user.Country
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
