using SeniorConnect.Application.Interfaces;
using SeniorConnect.Domain;

namespace SeniorConnect.Application.Services;
public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task CreateAccount(User user)
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

    public async Task<List<User>> GetAllAsync()
    {
        try
        {
            var users = await _userRepository.GetAllAsync();
            return users;
        }
        catch (Exception)
        {

            throw;
        }
    }

    public void DeleteAccount(int userId)
    {
        _userRepository.DeleteAccountAsync(userId);
    }
}
