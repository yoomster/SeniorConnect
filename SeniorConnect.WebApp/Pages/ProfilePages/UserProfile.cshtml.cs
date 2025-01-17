using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.Application.Services;
using SeniorConnect.Domain;

namespace SeniorConnect.WebApp.Pages.ProfilePages
{
    public class UserProfileModel : PageModel
    {
        private readonly UserService _userService;

        public User User { get; set; }

        public UserProfileModel(UserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> OnGet()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (userId == null)
            {
                return RedirectToPage("/IdentityAccessManagement/Login");
            }

            User = await _userService.GetById(userId.Value);

            if (User == null)
            {
                return RedirectToPage("/IdentityAccessManagement/Login");
            }

            return Page();
        }
    }
}
