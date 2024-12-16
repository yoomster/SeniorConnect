using System.ComponentModel.DataAnnotations;

namespace SeniorConnect.WebApp.Models
{
    public class AddressUI
    {
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
