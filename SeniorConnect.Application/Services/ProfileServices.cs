using SeniorConnect.Domain;
using System.Diagnostics.Metrics;
using System.IO;
using System.Reflection.Emit;

namespace SeniorConnect.Application.Services;

public class ProfileServices
{
    public async Task UpdateProfileAsync(User user)
    {
        ChangePassword(user.Password);
        ChangeMaritalStatus(user.MaritalStatus);
        ChangeAddress(user.StreetName, user.HouseNumber, user.Zipcode, user.City, user.Country);

    }
    public void ChangePassword(string password)
    {
    }

    public void ChangeMaritalStatus(MaritalEnum status)
    {

    }

    public void ChangeAddress(string street, string nr, string zipcode, string city, string country)
    {

    }
}
