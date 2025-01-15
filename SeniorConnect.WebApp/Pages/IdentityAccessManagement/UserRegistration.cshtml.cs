using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.Application.Services;
using SeniorConnect.WebApp.Mapping;
using SeniorConnect.WebApp.Models;

namespace SeniorConnect.WebApp.Pages.IdentityAccessManagement
{
    public class UserRegistrationModel : PageModel
    {
        private readonly UserService _userService;

        public UserRegistrationModel(UserService userService)
        {
            _userService = userService;

        }

        [BindProperty]
        public UserFormModel UserFormModel { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var userEntity = UserFormModel.ToUserEntity();
                await _userService.CreateAccount(userEntity);
                return RedirectToPage("Login");

            }

            catch (Exception ex)
            {
                Console.WriteLine($"Error registering user: {ex.Message}");
                return Page();
            }
        }
    }
}
