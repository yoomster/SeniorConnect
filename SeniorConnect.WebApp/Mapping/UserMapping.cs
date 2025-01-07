using SeniorConnect.Domain;
using SeniorConnect.WebApp.Models;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;
using System.Reflection;

namespace SeniorConnect.WebApp.Mapping;

public static class UserMapping
{
    public static User ToUserEntity(this UserFormModel formModel)
    {
        return new User(
            formModel.FirstName,
            formModel.LastName,
            formModel.Email,
            formModel.Password,
            formModel.DateOfBirth,
            formModel.Gender,
            formModel.Origin,
            formModel.MaritalStatus,
            formModel.StreetName,
            formModel.HouseNumber,
            formModel.Zipcode,
            formModel.City,
            formModel.Country);
    }
}

