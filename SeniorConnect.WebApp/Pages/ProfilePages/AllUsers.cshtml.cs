using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.Application.Services;
using SeniorConnect.Domain;

namespace SeniorConnect.WebApp.Pages.ProfilePages
{
    public class AllUsersModel : PageModel
    {
        private readonly UserService _userService;
        public IEnumerable<User> Users { get; set; }

        public AllUsersModel(UserService userService)
        {
            _userService = userService;
        }

        public async Task OnGet()
        {
            Users = await _userService.GetAllAsync();

            foreach (var user in Users)
            {
                Console.WriteLine($"User: {user.Id}, {user.FirstName} {user.LastName}");
            }
        }
    }
}