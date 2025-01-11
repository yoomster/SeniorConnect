using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.Domain;

namespace SeniorConnect.WebApp.Pages.ActivityPages
{
    public class AllActivitiesListedModel : PageModel
    {
        //private readonly ActivityRepository _activityRepository;
        public List<Activity> AllActivities { get; set; }

        //public AllActivitiesListedModel(ActivityRepository repo)
        //{
        //    _activityRepository = repo;
        //}

        public void OnGet()
        {
            //List<Activity> activities = _activityRepository.GetActivities();

            //foreach (var activity in activities)
            //{
            //    Console.WriteLine($"User: {activity.Name} {activity.Description}");
            //}
            //AllActivities = activities;

            // Hier wordt normaal gesproken de data uit de database opgehaald.
        //    Activities = new List<Activity>
        //{
        //    new Activity { Id = 1, Name = "Sjoelen met Senioren", Date = new DateTime(2025, 2, 5), StartTime = new TimeSpan(14, 0, 0), City = "Eindhoven" },
        //    // Voeg meer activiteiten toe
        //};
        }

    }
}

