using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.Domain;

namespace SeniorConnect.WebApp.Pages.ActivityPages
{
    public class DetailsModel : PageModel
    {
        public Activity Activity { get; set; }
        public void OnGet(int id)
        {

            //Activity = activities.FirstOrDefault(a => a.Id == id) ?? new Activity();
        }
    }
}
