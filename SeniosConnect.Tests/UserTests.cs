using SeniorConnect.Domain;
using SeniorConnect.Application.Services;


namespace SeniorConnect.Tests;

public class UserTests
{
    public void TestAdd()
    {
        var user = new User(
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
        country: "Netherlands"
    );

        //var user.CreateAccount();
    }

    //Valid Input:ctor inits object correctly when all inputs are valid.
    [Fact]
    public void User_Creation_WithValidInput_ShouldSucceed()
    {

    }

    //Invalid Email Test: Test with invalid email formats to verify validation 
    [Fact]
    public void User_Creation_WithInvalidEmail_ShouldThrowException()
    {

    }

    //Test for duplicate email addresses
    [Fact]
    public void User_Creation_WithDiplicateEmail_ShouldThrowException()
    {

    }

    //participant cannot reserve overlapping activities

}
