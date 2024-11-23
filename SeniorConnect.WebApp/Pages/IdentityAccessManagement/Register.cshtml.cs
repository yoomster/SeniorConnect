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
        public UserRegistration Registration { get; set; }

        public void OnGet()
        {
        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            return RedirectToPage("Login");

            User user = new()
            {
                FirstName = Registration.FirstName,
                LastName = Registration.LastName,
                Email = Registration.Email,
                Password = Registration.Password
            };

            try
            {
                _userRepository.SaveUserToDB(user);
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
