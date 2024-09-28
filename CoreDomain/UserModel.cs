using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDomain
{
    public class UserModel
    {
        [Required(ErrorMessage = "Required field")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Required field")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
