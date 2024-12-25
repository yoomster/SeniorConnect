using CoreDomain;
using CoreDomain.Users;
using SeniorConnect.WebApp.Models;

namespace SeniorConnect.WebApp.Mapping;

public static class UserMapping
{
    public static User ToUserEntity(this UserFormModel formModel)
    {
        var newUser = new User
        {
            Email = formModel.Email,
            FirstName = formModel.FirstName,
            LastName = formModel.LastName,
            Password = formModel.Password,
            DateOfBirth = formModel.DateOfBirth.Date,
            City = formModel.City,
            Country = formModel.Country,
            HouseNumber = formModel.HouseNumber,
            StreetName = formModel.StreetName,
            Zipcode = formModel.Zipcode,
        };
    }
}
