using System.ComponentModel.DataAnnotations;

namespace SeniorConnect.WebApp.Models
{
    public class UserRegistration
    {
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
        public char Gender { get; set; } 
        public string Origin { get; set; } // can be an enum too
        public string IBAN { get; set; }
    }
}
