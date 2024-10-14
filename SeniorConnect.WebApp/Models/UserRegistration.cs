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
    }
}
