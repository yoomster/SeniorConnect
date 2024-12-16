using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDomain
{
    public class Address
    {
        public int Id;
        public string? StreetName { get; set; }
        public string? HouseNumber { get; set; }
        public string? Zipcode { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }
    }
}
