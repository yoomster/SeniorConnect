using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.Application.Services;
using SeniorConnect.WebApp.Mapping;
using SeniorConnect.WebApp.Models;

namespace SeniorConnect.WebApp.Pages.IdentityAccessManagement
{
    public class UserRegistrationModel : PageModel
    {
        private readonly IdentityService _identityService;

        public UserRegistrationModel(IdentityService identityService)
        {
            _identityService = identityService;

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
                await _identityService.CreateAccount(userEntity);
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
