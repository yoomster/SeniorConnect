namespace SeniorConnect.WebApp.Models
{
    public class UserDetails
    {
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string Zipcode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public DateOnly? DateOfBirth { get; set; }
        public char? Gender { get; set; }
        public string? Iban { get; set; }



    }
}
