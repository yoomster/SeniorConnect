using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.Application.Services;
using System.Security.Claims;

namespace SeniorConnect.WebApp.Pages.IdentityAccessManagement
{
    public class LoginModel : PageModel
    {
        private readonly IdentityService _identiyService;

        public LoginModel(IdentityService identiyService)
        {
            _identiyService = identiyService;
        }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync(string email, string password)
        {
            var user = await _identiyService.LoginAsync(email, password);

            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.Id);

                // Create user claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.FirstName)
                };

                // Create claims identity and sign in
                var claimsIdentity = new ClaimsIdentity(claims, "CookieAuthentication");
                await HttpContext.SignInAsync("CookieAuthentication", new ClaimsPrincipal(claimsIdentity));

                return RedirectToPage("/ActivityPages/ActivitiesCalendar");
            }
            else if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError("", "Email and Password are required.");
                return Page();
            }

            ModelState.AddModelError("", "Invalid username or password.");
            return Page();
        }
    }
}