using FluentAssertions;
using SeniorConnect.Application.Services;
using SeniorConnect.Application.Interfaces;
using NSubstitute;
using SeniorConnect.Domain;
using System.Collections.Generic;

namespace SeniorConnect.Tests;

public class UserTests
{
    private readonly IUserRepository _userRepository = Substitute.For<IUserRepository>();
    private readonly UserService _sut;

    public UserTests()
    {
        _sut = new UserService(_userRepository);
    }

    //Arrange
    User TestUser = new User(
        firstName: "Adam",
        lastName: "Akil",
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

    //Validation logic 4 user, may need mocking any dependencies or
    //add additional assertions to handle specific validation cases.

    //Valid Input:ctor inits object correctly when all inputs are valid.
    [Fact(Skip = "testing")]
    public void UserCreationWithValidInput_ShouldSucceed()
    {
        ////Arange
        //_sut.CreateAccount(TestUser);

        ////Act
        //_userRepository.CreateUserAsync(TestUser).Returns(expectedUsers);

        

        //var email = sut.Email;
        //var password = sut.Password;

        //var dateOfBirth = sut.DateOfBirth;
        //var today = DateOnly.FromDateTime(DateTime.Now);
        //var age = today.Year - dateOfBirth.Year;



        //Assert
        //can we test if all props are included 
        //email.Should().NotBeEmpty();
        //email.Should().Contain("@");

        //password.Should().NotBeEmpty();

        //age.Should().BePositive();
        //age.Should().BeGreaterThan(60);
    }


    [Fact(Skip = "testing")]
    public void UserCreationWithInvalidEmail_ShouldThrowException()
    {
        ////    var invalidEmail = sut.Email.Remove(6);

        ////    //Act (should be a method instead?)
        ////    Action result = () => (invalidEmail);

        //    //Assert
        //    result.Should().Throw<ArgumentException>()
        //        .WithMessage("Invalid email address.");

    }

  
    [Fact(Skip = "testing")]
    public void UserCreationWithDuplicateEmail_ShouldThrowException()
    {

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
            new User(
            firstName: "Adam",
            lastName: "Akil",
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
            country: "Netherlands")
        };

        _userRepository.GetAllAsync().Returns(expectedUsers);
        
        //Act
        var users = await _sut.GetAllAsync();

        //Assert
        users.Should().Contain(expectedUsers);
        users.Should().ContainSingle(x => x.FirstName == "Adam");


    }
}
