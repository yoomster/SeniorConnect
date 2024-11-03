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
        public string EmailAddress { get; init; }

        [Required(ErrorMessage = "Required field!")]
        [DataType(DataType.Password)]
        public string Password { get; init; }

        [Required(ErrorMessage = "Required field!")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; init; }

        public DateTimeOffset DateOfBirth { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Gender { get; set; } // check if this is the best type
        public string Origin { get; set; } // can be an enum too
        public string IbanAccountNumber { get; set; }
        public DateTimeOffset DateOfRegistration { get; set; }
    }
}
