using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDomain.Users;

public class User
{
    public int Id;
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; } 
    public required string Password { get; set; } 
    public DateOnly DateOfBirth { get; set; }
    public required char Gender { get; set; } 
    public required string Origin { get; set; }
    public DateOnly DateOfRegistration { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public required string StreetName { get; set; }
    public required string HouseNumber { get; set; }
    public required string Zipcode { get; set; }
    public required string City { get; set; }
    public required string Country { get; set; }
}