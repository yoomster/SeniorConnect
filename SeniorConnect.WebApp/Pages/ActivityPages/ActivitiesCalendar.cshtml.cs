using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.Application.Interfaces;
using SeniorConnect.Domain;

namespace SeniorConnect.WebApp.Pages.ActivityPages
{
    public class ActivitiesCalendarModel : PageModel
    {
        private readonly IActivityRepository _activityRepository;
        public List<Activity> Activities { get; set; }

        public ActivitiesCalendarModel(IActivityRepository activityRepository)
        {
            _activityRepository = activityRepository;
        }

        public async Task OnGet()
        {
            List<Activity> activities = await _activityRepository.GetAllAsync();

            foreach (var activity in activities)
            {
                Console.WriteLine($"Activity: {activity.Title}, {activity.Date} {activity.StartTime}, {activity.City}");
            }

            Activities = activities;
        }
    }
}
