using FluentAssertions;
using SeniorConnect.Application.Services;
using SeniorConnect.Application.Interfaces;
using NSubstitute;
using SeniorConnect.Domain;

namespace SeniorConnect.Tests;

public class UserTests
{
    private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();
    private readonly UserService _sut;

    public UserTests()
    {
        var ageValidator = new AgeValidator();
        var passwordValidator = new PasswordStrengthValidator();
        var emailValidator = new EmailValidator(_userRepository);

        var compositionValidator = new CompositionValidator(new List<IValidator>
        {
            ageValidator,
            passwordValidator,
            emailValidator
        });

        _sut = new UserService(_userRepository, compositionValidator);
    }

    //Arrange
    User user = new User(
        firstName: "Adam",
        lastName: "Man",
        email: "aa@example.com",
        password: "Password123",
        dateOfBirth: new DateOnly(1955, 8, 20),
        gender: 'M',
        origin: "Social Media",
        maritalStatus: MaritalEnum.Married,
        streetName: "Main Street",
        houseNumber: "104",
        zipcode: "5616TZ",
        city: "Eindhoven",
        country: "Netherlands");


    [Fact]
    public async void UserCreationWithValidEmail_ShouldReturnSuccess_WhenEmailValidatorSucceed()
    {
        //Arrange
        _userRepository.IsEmailDuplicate(Arg.Any<string>()).Returns(false);

        //Act
        var result = await _sut.CreateAccount(user);

        //Assert
        result.IsSuccess.Should().BeTrue();
        result.Messages.Should().BeEmpty();
    }


    [Fact]
    public async void UserCreationWithDuplicateEmail_ShouldReturnUserFriendlyErrorMessage_WhenEmailValidatorFails()
    {
        //Arrange
        _userRepository.IsEmailDuplicate(Arg.Any<string>()).Returns(true);

        //Act 
        var result = await _sut.CreateAccount(user);


        //Assert
        result.IsSuccess.Should().BeFalse();
        result.Messages.Should().NotBeEmpty();
        result.Messages.Should().Contain("Validator: Het opgegeven e-mailadres wordt al gebruikt.");
    }


    [Fact]
    public async void GetallAsync_ShouldReturnEmptyList_WhenNoUsersExist()
    {
        //Arrange
        _userRepository.GetAllAsync().Returns(Array.Empty<User>());

        //Act
        var users = await _sut.GetAllAsync();

        //Assert
        users.Should().BeEmpty();
    }


    [Fact]
    public async Task GetAllAsync_ShouldReturnAListOfUsers_WhenUsersExist()
    {
        //Arrange
        var expectedUsers = new[]
        {
            user,
        };

        _userRepository.GetAllAsync().Returns(expectedUsers);
        
        //Act
        var users = await _sut.GetAllAsync();

        //Assert
        users.Should().Contain(expectedUsers);
        users.Should().ContainSingle(x => x.FirstName == "Adam");


    }
}
