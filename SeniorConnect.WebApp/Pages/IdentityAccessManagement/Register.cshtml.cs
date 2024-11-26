using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.WebApp.Models;
using SeniorConnect.DataAccesLibrary;
using CoreDomain.Users;

namespace SeniorConnect.WebApp.Pages.IdentityAccessManagement
{
    public class RegisterModel : PageModel
    {
        private readonly UserRepository _userRepository;

        [BindProperty]
        public UserDTO Registration { get; set; }

        public RegisterModel(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void OnGet()
        {
        }

        public ActionResult OnPost()
        {
            //validate the data

            if (!ModelState.IsValid)
            {
                return Page();
            }

            User newUser = new User
            {
                FirstName = Registration.FirstName,
                LastName = Registration.LastName,
                Email = Registration.Email,
                Password = Registration.Password
            };

            //_userRepository.SaveUserToDB(newUser);


            try
            {
                _userRepository.SaveUserToDB(newUser);
                TempData["SuccessMessage"] = "User registered successfully!";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Error registering user: " + ex.Message;
                return Page(); // change this to handle the exception!! 
            }

            return RedirectToPage("Login");
        }
    }
}
