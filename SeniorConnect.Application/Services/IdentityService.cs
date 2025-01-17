using SeniorConnect.Application.Interfaces;
using SeniorConnect.Domain;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace SeniorConnect.Application.Services
{
    public class IdentityService 
    {
        private readonly IUserRepository _userRepository;

        public IdentityService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
       
        public async Task<User?> LoginAsync(string email, string password)
        {
            bool isValidUser = await ValidateUserAsync(email, password);

            if (isValidUser)
                return await _userRepository.GetByEmailAsync(email);
            else 
                return null;
        }

        public async Task<bool> ValidateUserAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            if (user == null)
                return false;

            var hashedPassword = PasswordHashing.HashPassword(password);
            return user.Password == hashedPassword;
        }

        public void Logout()
        {

        }


    }
}
