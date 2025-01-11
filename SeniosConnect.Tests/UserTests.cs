using SeniorConnect.Domain;


namespace SeniorConnect.Tests;

public class UserTests
{
    User validUser = new(
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
    public void User_Creation_WithValidInput_ShouldSucceed()
    {
        //Arrange
        //Act


        //Assert
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
