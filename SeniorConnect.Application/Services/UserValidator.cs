using SeniorConnect.Application.Interfaces;
using SeniorConnect.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeniorConnect.Application.Services
{
    public class AgeValidator : IValidator
    {
        public async Task<ValidationResult> IsValid(User user)
        {
            var result = new ValidationResult { IsSuccess = true };

            var minimumDateOfBirth = DateTime.Now.AddYears(-60).Date;
            if (user.DateOfBirth > DateOnly.FromDateTime(minimumDateOfBirth))
            {
                result.IsSuccess = false;
                result.Messages.Add("U moet minimaal 60 jaar oud zijn om u in te schrijven.");
            }
            return result;
        }
    }

    public class EmailValidator : IValidator
    {
        private readonly IUserRepository _userRepo;
        public EmailValidator(IUserRepository userRepo)
        {
            _userRepo = userRepo;            
        }

        public async Task<ValidationResult> IsValid(User user)
        {
            var result = new ValidationResult { IsSuccess = true };

            if (await _userRepo.IsEmailDuplicate(user.Email))
            {
                result.IsSuccess = false;
                result.Messages.Add("Het opgegeven e-mailadres wordt al gebruikt.");
            }

            return result;

        }
    }

    public class PasswordStrengthValidator : IValidator
    {
        public async Task<ValidationResult> IsValid(User user)
        {
            var result = new ValidationResult { IsSuccess = true };

            if (user.Password.Length < 6)
            {
                result.IsSuccess = false;
                result.Messages.Add("Wachtwoord moet min. 6 char lang zijn.");
            }

            return result;
        }
    }
}
