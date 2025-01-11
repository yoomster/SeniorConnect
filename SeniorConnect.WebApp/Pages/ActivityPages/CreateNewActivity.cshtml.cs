using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.Application.Services;
using SeniorConnect.WebApp.Mapping;
using SeniorConnect.WebApp.Models;

namespace SeniorConnect.WebApp.Pages.ActivityPages
{
    public class CreateNewActivityModel : PageModel
    {
        private readonly ActivityService _activityService;

        public CreateNewActivityModel(ActivityService activityService)
        {
            _activityService = activityService;
        }

        [BindProperty]
        public ActivityFormModel ActivityFormModel { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var activityEntity = ActivityFormModel.ToActivityEntity();
                await _activityService.RegisterActivity(activityEntity);

                TempData["SuccessMessage"] = "activity registered successfully!";
                return RedirectToPage("Login");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error registering activity: {ex.Message}");
                TempData["ErrorMessage"] = "An error occurred while registering. Please try again later.";
                return Page();
            }
        }
    }
}
