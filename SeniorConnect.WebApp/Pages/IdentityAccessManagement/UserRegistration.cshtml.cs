using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.Application.Services;
using SeniorConnect.Domain;
using SeniorConnect.WebApp.Mapping;
using SeniorConnect.WebApp.Models;
using System.ComponentModel.DataAnnotations;

namespace SeniorConnect.WebApp.Pages.IdentityAccessManagement
{
    public class UserRegistrationModel : PageModel
    {
        private readonly UserService _userService;

        public UserRegistrationModel(UserService userService)
        {
            _userService = userService;
            ErrorMessages = new List<string>();
        }

        [BindProperty]
        public UserFormModel UserFormModel { get; set; }

        public List<string> ErrorMessages { get; set; }


        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //try
            //{
            //    var userEntity = UserFormModel.ToUserEntity();
            //    var result = await _userService.CreateAccount(userEntity);

            //    if (!result.IsSuccess)
            //    {
            //        ErrorMessages = result.Messages;
            //        return Page(); 
            //    }

            //    return RedirectToPage("Login");
                
            //}
            try
            {
                var userEntity = UserFormModel.ToUserEntity();
                var success = await _userService.CreateAccount(userEntity);

                if (success.IsSuccess)
                {
                    return RedirectToPage("/Index");
                }

                ErrorMessages = success.Messages;
            }

            catch (Exception ex)
            {
                ErrorMessages.Add(ex.Message);
            }

            return Page();

        }
    }
}
