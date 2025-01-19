using SeniorConnect.Application.Interfaces;
using SeniorConnect.Domain;

namespace SeniorConnect.Application.Services;
public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly CompositionValidator _compositionValidator;

    public UserService(IUserRepository userRepository, CompositionValidator compValidator)
    {
        _userRepository = userRepository;
        _compositionValidator = compValidator;
    }

    public async Task<ValidationResult> CreateAccount(User user)
    {
        var validationResult = await _compositionValidator.IsValid(user);

        if (validationResult.IsSuccess)
        {
            var hashedPassword = PasswordHashing.HashPassword(user.Password);

            User newUser = new(
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
            await _userRepository.CreateUserAsync(newUser);
            return new ValidationResult { IsSuccess = true };
        }

        return validationResult;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _userRepository.GetAllAsync();
    }

    public async Task<User> GetById(int id)
    {
        return await _userRepository.GetByIdAsync(id);
    }

    public async Task<User> GetByEmail(string email)
    {
        return await _userRepository.GetByEmailAsync(email);
    }

    public async Task DeleteAccount(int userId)
    {
        await _userRepository.DeleteByIdAsync(userId);
    }

}
