using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.Application.Interfaces;
using SeniorConnect.Application.Services;
using SeniorConnect.Domain;

namespace SeniorConnect.WebApp.Pages.ActivityPages
{
    public class ActivitiesCalendarModel : PageModel
    {
        private readonly ActivityService _activityService;
        public List<Activity> Activities { get; set; }

        public ActivitiesCalendarModel(ActivityService activityService)
        {
            _activityService = activityService;
        }

        public async Task OnGet()
        {
            List<Activity> activities = await _activityService.GetAllAsync();

            foreach (var activity in activities)
            {
                Console.WriteLine($"Activity: {activity.Title}, {activity.Date} {activity.StartTime}, {activity.City}");
            }

            Activities = activities;
        }
    }
}
