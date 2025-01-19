using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.Application.Services;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace SeniorConnect.WebApp.Pages.IdentityAccessManagement
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        [Required(ErrorMessage = "Email is verplicht")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [BindProperty]
        [StringLength(32, MinimumLength = 6)]
        [Required(ErrorMessage = "Wachtwoord is verplicht")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public List<string> ErrorMessages { get; set; } = new List<string>();
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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var user = await _identiyService.LoginAsync(email, password);

                HttpContext.Session.SetInt32("UserId", user.Id);

                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, user.FirstName));
                claims.Add(new Claim("Id", user.Id.ToString()));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity)); 

                return RedirectToPage("/Index");
 
            }
            catch (UnauthorizedAccessException ex)
            {
                ErrorMessages.Add(ex.Message);
            }
            catch (Exception)
            {
                ErrorMessages.Add("Oops! Er gaat iets mis aan onze kant. We gaan hier mee aan de slag!");
            }
            return Page();

         }
    }
}