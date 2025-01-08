using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SeniorConnect.WebApp.Models
{
    public class ActivityUI
    {
        [Required(ErrorMessage = "Required field!")]
        public string Name { get; init; }

        [Required(ErrorMessage = "Required field!")]
        public string Description { get; init; }

        [Required(ErrorMessage = "Required field!")]
        public DateOnly Date { get; init; }

        [Required(ErrorMessage = "Required field!")]
        public TimeOnly StartTime { get; init; }

        [Required(ErrorMessage = "Required field!")]
        public TimeOnly EndTime { get; init; }

        [Required(ErrorMessage = "Required field!")]
        public int MaxParticipants { get; init; }

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

