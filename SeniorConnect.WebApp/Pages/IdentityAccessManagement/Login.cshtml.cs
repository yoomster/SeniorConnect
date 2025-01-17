using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.Application.Services;
using SeniorConnect.Domain;
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
            if (User.Identity.IsAuthenticated)
            {
                Response.Redirect("/ProfilePages/UserProfile");
            }
        }

        public async Task<IActionResult> OnPostAsync(string email, string password)
        {
            var user = await _identiyService.LoginAsync(email, password);

            if (user != null)
            {
                HttpContext.Session.SetInt32("UserId", user.Id);


                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.FirstName));
                claims.Add(new Claim("Id", user.Id.ToString()));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));


         
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