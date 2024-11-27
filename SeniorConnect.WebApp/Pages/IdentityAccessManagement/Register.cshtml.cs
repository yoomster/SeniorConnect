using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.WebApp.Models;
using SeniorConnect.DataAccesLibrary;
using CoreDomain.Users;
using SeniorConnect.Domain.Contracts;

namespace SeniorConnect.WebApp.Pages.IdentityAccessManagement
{
    public class RegisterModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        [BindProperty]
        public UserFormModel UserFormModel { get; set; }

        public RegisterModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void OnGet()
        {
        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                User newUser = new User
                {
                FirstName = UserFormModel.FirstName,
                LastName = UserFormModel.LastName,
                Email = UserFormModel.Email,
                Password = UserFormModel.Password
                };

                //check for user with email

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
