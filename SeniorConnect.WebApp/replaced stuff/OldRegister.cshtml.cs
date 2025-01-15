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

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            return Page();


            //try
            //{
            //    var userEntity = UserFormModel.ToUserEntity();
            //    await _identityService.CreateAccount(userEntity);

            //    //TempData["SuccessMessage"] = "User registered successfully!";
            //    return RedirectToPage("Login");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Error registering user: {ex.Message}");
            //    //TempData["ErrorMessage"] = "An error occurred while registering. Please try again later.";
            //    return Page();
            //}
        }
    }
}

