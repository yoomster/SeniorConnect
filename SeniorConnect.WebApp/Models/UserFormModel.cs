using Microsoft.AspNetCore.Mvc;
using SeniorConnect.Domain;
using System.ComponentModel.DataAnnotations;

namespace SeniorConnect.WebApp.Models
{
    public class UserFormModel
    {
        public UserFormModel()
        {
                
        }

        [Required(ErrorMessage = "Required field!")]
        public string FirstName { get; init; }

        [Required(ErrorMessage = "Required field!")]
        public string LastName { get; init; }

        [Remote(action: "VerifyEmail", controller: "Users")] //implement JS method
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

        [Required(ErrorMessage = "Required field!")]
        [DataType(DataType.Date)]
        //[MinAge(60, ErrorMessage = "User must be at least 60 years old.")] // LOOK INTO 
        public DateOnly DateOfBirth { get; set; }

        [Required(ErrorMessage = "Required field!")]
        public char Gender { get; set; }
        
        [Required(ErrorMessage = "Required field!")]
        public string Origin { get; set; }

        [Required(ErrorMessage = "Required field!")]
        public MaritalEnum MaritalStatus { get; set; }

        [Required(ErrorMessage = "Required field!")]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "Required field!")]
        public string HouseNumber { get; set; }

        [Required(ErrorMessage = "Required field!")]
        [RegularExpression(@"^\d{4}\s?[A-Z]{2}$", ErrorMessage = "Invalid Zipcode format.")]
        public string Zipcode { get; set; }

        [Required(ErrorMessage = "Required field!")]
        public string City { get; set; }

        [Required(ErrorMessage = "Required field!")]
        public string Country { get; set; }
    }
}
