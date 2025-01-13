using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.Application.Services;
using SeniorConnect.Domain;

namespace SeniorConnect.WebApp.Pages.ActivityPages
{
    public class DetailsModel : PageModel
    {
        private readonly ActivityService _activityService;
        public Activity Activity { get; set; }

        public DetailsModel(ActivityService activityService)
        {
            _activityService = activityService;
        }
        public async Task<IActionResult> OnGet(int id)
        {
            var activity = await _activityService.GetActivityById(id);

            if (activity == null)
            {
                return NotFound();
            }

                Activity = activity;
            
            return Page();
        }
    }
}
