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
            FirstName = formModel.FirstName,
            LastName = formModel.LastName,
            Email = formModel.Email,
            Password = formModel.Password,
            DateOfBirth = formModel.DateOfBirth,
            Gender = formModel.Gender,
            Origin = formModel.Origin,
            StreetName = formModel.StreetName,
            HouseNumber = formModel.HouseNumber,
            Zipcode = formModel.Zipcode,
            City = formModel.City,
            Country = formModel.Country,
        };

        return newUser;
    }
}

