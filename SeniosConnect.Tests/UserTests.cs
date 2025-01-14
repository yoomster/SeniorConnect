using FluentAssertions;
using SeniorConnect.Domain;
using SeniorConnect.Application.Services;



namespace SeniorConnect.Tests;

public class UserTests
{
    private 
    //Arrange
    User sut = new(
    firstName: "Adam",
    lastName: "Akil",
    email: "adam.akil@example.com",
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


    //If the User class has any validation logic, you may need to mock any dependencies or
    //add additional assertions to handle specific validation cases.
    
    //Valid Input:ctor inits object correctly when all inputs are valid.
    [Fact]
    public void UserCreationWithValidInput_ShouldSucceed()
    {
        //Act
        var email = sut.Email;
        var password = sut.Password;

        var dateOfBirth = sut.DateOfBirth;
        var today = DateOnly.FromDateTime(DateTime.Now);
        var age = today.Year - dateOfBirth.Year;



        //Assert
        //can we test if all props are included 
        email.Should().NotBeEmpty();
        email.Should().Contain("@");

        password.Should().NotBeEmpty();

        age.Should().BePositive();
        age.Should().BeGreaterThan(60);
    }

    //Invalid Email Test: Test with invalid email formats to verify validation 
    [Fact(Skip = "testing")]
    public void UserCreationWithInvalidEmail_ShouldThrowException()
    {
        var invalidEmail = sut.Email.Remove(6);

        //Act (should be a method instead?)
        Action result = () => (invalidEmail);

        //Assert
        result.Should().Throw<ArgumentException>()
            .WithMessage("Invalid email address.");
        
    }

    //Test for duplicate email addresses
    [Fact(Skip = "testing")]
    public void User_Creation_WithDiplicateEmail_ShouldThrowException()
    {

    }

    //participant cannot reserve overlapping activities

}
