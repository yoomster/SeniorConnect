using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.Application.Interfaces;
using SeniorConnect.Application.Services;
using SeniorConnect.Domain;
using SeniorConnect.WebApp.Mapping;
using SeniorConnect.WebApp.Models;

namespace SeniorConnect.WebApp.Pages.ProfilePages
{
    public class UpdatePersonDataModel : PageModel
    {
        private readonly ProfileService _profileService;

        [BindProperty]
        public UserFormModel UserFormModel { get; set; }

        public UpdatePersonDataModel( ProfileService profileService)
        {
            _profileService = profileService;
        }

        public async Task<ActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var userEntity = UserFormModel.ToUserEntity();

                await _profileService.UpdateProfileAsync(userEntity);

                return RedirectToPage("Profile");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while updating data. Please try again.");
                Console.WriteLine("Error updating user or address: " + ex.Message);
                return Page();
            }
        }
    }
}
