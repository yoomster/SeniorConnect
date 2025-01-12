using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.Application.Interfaces;
using SeniorConnect.Application.Services;
using SeniorConnect.WebApp.Mapping;
using SeniorConnect.WebApp.Models;

namespace SeniorConnect.WebApp.Pages.ActivityPages
{
    public class CreateNewActivityModel : PageModel
    {
        //private readonly IActivityRepository _activityRepository;
        private readonly IUserRepository _userRepository;
        private readonly ActivityService _activityService;
        public CreateNewActivityModel(IUserRepository userRepository, ActivityService activityService)
        {
            //_activityRepository = activityRepository;
            _userRepository = userRepository;
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

            int? loggedInUserId = HttpContext.Session.GetInt32("UserId");

            if (loggedInUserId.HasValue)
            {

                try
                {
                    var activityEntity = ActivityFormModel.ToActivityEntity();
                    await _activityService.CreateActivity(activityEntity, loggedInUserId.Value);


                    TempData["SuccessMessage"] = "activity registered successfully!";
                    return RedirectToPage("Login");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error registering activity: {ex.Message}");
                    TempData["ErrorMessage"] = "An error occurred while registering.";
                    return Page();
                }
            }
            else
            {
                TempData["ErrorMessage"] = "You must be logged in to create an activity.";
                return RedirectToPage("Login");
            }
        }
    }
}
