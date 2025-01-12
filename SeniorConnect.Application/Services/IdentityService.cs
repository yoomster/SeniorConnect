using SeniorConnect.Application.Interfaces;
using SeniorConnect.Domain;
using System.Security.Cryptography;
using System.Text;

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
        public async Task CreateAccount(User user)
        {           
            var hashedPassword = HashPassword(user.Password);

            User newUser = new User(
                    firstName: user.FirstName,
                    lastName: user.LastName,
                    email: user.Email,
                    password: hashedPassword,
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

                await _userRepository.CreateUserInDBAsync(newUser);
        }

        //public async Task<int> GetLoggedInUserId()
        //{
        //    await _userRepository.
        //}

        public async Task LoginAsync(string email, string password)
        {
            bool isValidUser = await ValidateUserAsync(email, password);

            if (isValidUser)
            {
                var user = await _userRepository.GetByEmailAsync(email);
            }
        }

        public async Task<bool> ValidateUserAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            if (user == null)
                return false;

            var hashedPassword = HashPassword(password);
            return user.Password == hashedPassword;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(hashedBytes);
            }
        }

        public void Logout()
        {
            //static ISession.Clear();
        }

        public void DeleteAccount(int userId)
        {
            _userRepository.DeleteAccountAsync(userId);
        }
    }
}
