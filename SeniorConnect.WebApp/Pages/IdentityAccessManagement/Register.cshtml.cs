using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.WebApp.Models;
using SeniorConnect.WebApp.Mapping;
using SeniorConnect.Application.Services;


namespace SeniorConnect.WebApp.Pages.IdentityAccessManagement
{
    public class RegisterModel : PageModel
    {
        private readonly IdentityService _identityService;

        public RegisterModel(IdentityService identityService)
        {
            _identityService = identityService;
        }

        [BindProperty]
        public UserFormModel UserFormModel { get; set; }

        public void OnGet()
        {
        }

        //[AcceptVerbs("GET", "POST")]
        //public IActionResult VerifyEmail(string email)
        //{
        //    if (!_userService.VerifyEmail(email))
        //    {
        //        return Json($"Email {email} is already in use.");
        //    }

        //    return Json(true);
        //}

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var userEntity = UserFormModel.ToUserEntity();
                await _identityService.CreateAccount(userEntity);

                TempData["SuccessMessage"] = "User registered successfully!";
                return RedirectToPage("Login");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error registering user: {ex.Message}");
                TempData["ErrorMessage"] = "An error occurred while registering. Please try again later.";
                return Page();
            }
        }
    }
}

