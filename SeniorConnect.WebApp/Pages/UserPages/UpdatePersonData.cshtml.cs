using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.DataAccesLibrary;
using SeniorConnect.Domain.Contracts;
using SeniorConnect.WebApp.Models;

namespace SeniorConnect.WebApp.Pages.UserPages
{
    public class UpdatePersonDataModel : PageModel
    {
        private readonly IUserRepository _userRepository;


        [BindProperty]
        public UserFormModel UserFormModel { get; set; }


        public UpdatePersonDataModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void OnGet()
        {
        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
            }
            return RedirectToPage("Login");

        }
    }
