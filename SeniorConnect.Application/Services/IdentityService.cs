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

        public async Task<User> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            if (user == null)
            {
                throw new UnauthorizedAccessException("Onjuiste inloggegevens");
            }
            var validPassword = PasswordHashing.VerifyPasswordHash(password, user.Password);
            if (!validPassword)
            {
                throw new UnauthorizedAccessException("Onjuiste inloggegevens");
            }
            
            return user;
        }



        public async Task<bool> ValidateUserAsync(string email, string password)
        {
            bool result = true;

            var user = await _userRepository.GetByEmailAsync(email);
            var validPassword = PasswordHashing.VerifyPasswordHash(password, user.Password);

            if (user == null || !validPassword)
            {
                result = false;
            }

            return result;
        }

        public async Task<bool> Logout(int id)
        {
            return true;
        }


    }
}
