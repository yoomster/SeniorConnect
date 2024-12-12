using System.ComponentModel.DataAnnotations;

namespace SeniorConnect.WebApp.Models
{
    public class UserFormModel
    {
        public UserFormModel()
        {
            
        }
        public UserFormModel(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Required field!")]
        public string FirstName { get; init; }

        [Required(ErrorMessage = "Required field!")]
        public string LastName { get; init; }

        [Required(ErrorMessage = "Required field!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; init; }

        [Required(ErrorMessage = "Required field!")]
        [DataType(DataType.Password)]
        public string Password { get; init; }

        [Required(ErrorMessage = "Required field!")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; init; }

        public DateOnly DateOfBirth { get; set; }

        public char? Gender { get; set; } = 'N';

        [DataType(DataType.CreditCard)]
        public string? Iban { get; set; }

        public string? StreetName { get; set; }

        public string? HouseNumber { get; set; }

        [DataType(DataType.PostalCode)]
        public string? Zipcode { get; set; }

        public string? City { get; set; }

        public string? Country { get; set; }


    }
}
