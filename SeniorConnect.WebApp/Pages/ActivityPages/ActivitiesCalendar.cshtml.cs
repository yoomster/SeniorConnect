using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.Application.Interfaces;
using SeniorConnect.Application.Services;
using SeniorConnect.Domain;

namespace SeniorConnect.WebApp.Pages.ActivityPages
{
    [Authorize]

    public class ActivitiesCalendarModel : PageModel
    {
        private readonly ActivityService _activityService;
        public IEnumerable<Activity> Activities { get; set; }

        public ActivitiesCalendarModel(ActivityService activityService)
        {
            _activityService = activityService;
        }

        public async Task OnGet()
        {
            Activities = await _activityService.GetAllAsync();

            foreach (var activity in Activities)
            {
                Console.WriteLine($"Activity: {activity.Title}, {activity.Date} {activity.StartTime}, {activity.City}");
            }
        }
    }
}
