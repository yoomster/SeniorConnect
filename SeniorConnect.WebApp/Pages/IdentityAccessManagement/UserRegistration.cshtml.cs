using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.Application.Services;
using SeniorConnect.Domain;
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

        public List<string> ErrorMessages { get; set; } = new List<string>();


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
                var success = await _userService.CreateAccount(userEntity);

                if (success.IsSuccess)
                {
                    return RedirectToPage("/IdentityAccessManagement/Login");
                }

                ErrorMessages = success.Messages;
            }

            catch (Exception)
            {
                ErrorMessages.Add("Oops! Er gaat iets mis aan onze kant. We gaan hier mee aan de slag!");
            }
            return Page();

        }
    }
}
