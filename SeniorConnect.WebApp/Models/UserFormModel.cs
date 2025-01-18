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

        [Required(ErrorMessage = "Voornaam is verplicht.")]
        public string FirstName { get; init; }

        [Required(ErrorMessage = "Achternaam is verplicht.")]
        public string LastName { get; init; }

        [Required(ErrorMessage = "Email is verplicht.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; init; }

        [Required(ErrorMessage = "Wachtwoord is verplicht.")]
        [MinLength(5, ErrorMessage = "Wachtwoord moet minstens 6 tekens bevatten.")]
        [DataType(DataType.Password)]
        public string Password { get; init; }

        [Required(ErrorMessage = "Bevestig uw wachtwoord")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Wachtwoorden komen niet overeen.")]
        public string ConfirmPassword { get; init; }

        [Required(ErrorMessage = "Geboortedatum is verplicht")]
        [DataType(DataType.Date)]
        public DateOnly DateOfBirth { get; set; }

        [Required(ErrorMessage = "Selecteer uw geslacht")]
        public char Gender { get; set; }

        [Required(ErrorMessage = "Selecteer een optie")]
        public string Origin { get; set; }

        [Required(ErrorMessage = "Selecteer uw burgerlijke staat")]
        public MaritalEnum MaritalStatus { get; set; }

        [Required(ErrorMessage = "Straat is verplicht")]
        public string StreetName { get; set; }

        [Required(ErrorMessage = "Huisnummer is verplicht")]
        public string HouseNumber { get; set; }

        [Required(ErrorMessage = "Postcode is verplicht")]
        [RegularExpression(@"^\d{4}\s?[A-Z]{2}$", ErrorMessage = "Postcode format incorrect.")]
        public string Zipcode { get; set; }

        [Required(ErrorMessage = "Stad is verplicht")]
        public string City { get; set; }

        [Required(ErrorMessage = "Land is verplicht")]
        public string Country { get; set; }
    }
}
