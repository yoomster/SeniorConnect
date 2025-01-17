using SeniorConnect.Application.Interfaces;
using SeniorConnect.Domain;

namespace SeniorConnect.Application.Services;
public class UserService : IRegistrationValidator
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<bool> CanRegister(User user)
    {
        bool output = true;
        bool isEmailDuplicate = await IsEmailDuplicate(user.Email);
        var minimumDateOfBirth = DateTime.Now.AddYears(-60).Date;

        if (isEmailDuplicate)
        {
            output = false;
            throw new InvalidOperationException("Email is al geregistreerd.");
        }
        else if (user.DateOfBirth > DateOnly.FromDateTime(minimumDateOfBirth))
        {
            output = false;
            throw new ArgumentException("U moet minimaal 60 jaar oud zijn om bij ons in te schrijven.");
        }
        return output;
    }

    public async Task<bool> IsEmailDuplicate(string email)
    {
        var user = await _userRepository.GetByEmailAsync(email);
        return user != null;
    }

    public async Task CreateAccount(User user)
    {
        
        if (await CanRegister(user))
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
        }
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
