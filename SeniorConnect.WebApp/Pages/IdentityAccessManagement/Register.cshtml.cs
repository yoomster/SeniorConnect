using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.WebApp.Models;

namespace SeniorConnect.WebApp.Pages.IdentityAccessManagement
{
    public class RegisterModel : PageModel
    {
        [BindProperty]
        public UserRegistration Registration { get; set; }
        
        public void OnGet()
        {
        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // process data > DB SQL Server

            return RedirectToPage("Login");
        }
    }
}
