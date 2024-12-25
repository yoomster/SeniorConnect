using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.WebApp.Models;
using SeniorConnect.Domain.Services;
using SeniorConnect.WebApp.Mapping;

namespace SeniorConnect.WebApp.Pages.IdentityAccessManagement
{
    public class RegisterModel : PageModel
    {

        [BindProperty]
        public UserFormModel UserFormModel { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var userEntity = UserFormModel.ToUserEntity();
                await UserService.AddUser(userEntity);

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

