using CoreDomain.Users;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.DataAccesLibrary;
using SeniorConnect.Domain.Activity;

namespace SeniorConnect.WebApp.Pages.ActivityPages
{
    public class AllActivitiesListedModel : PageModel
    {
        private readonly ActivityRepository _activityRepository;
        public List<Activity> AllActivities { get; set; }

        public AllActivitiesListedModel(ActivityRepository repo)
        {
            _activityRepository = repo;
        }

        public void OnGet()
        {
            List<Activity> activities = _activityRepository.GetActivities();

            foreach (var activity in activities)
            {
                Console.WriteLine($"User: {activity.Name} {activity.Description}");
            }
            AllActivities = activities;
        }






    }
}
