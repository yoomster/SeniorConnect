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
    public required string Email { get; set; } // verification for uniqueness
    public required string Password { get; set; } // need to hash before sending to DB?
    public DateOnly? DateOfBirth { get; set; }
    public char? Gender { get; set; } 
    public string Origin { get; set; }
    public DateOnly DateOfRegistration { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public int AddressId { get; set; }
}