using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.Application.Interfaces;
using SeniorConnect.Application.Services;
using SeniorConnect.Domain;

namespace SeniorConnect.WebApp.Pages.ProfilePages
{
    public class AllUsersModel : PageModel
    {
        private readonly UserService _userService;
        public List<User> Users { get; set; }

        public AllUsersModel(UserService userService)
        {
            _userService = userService;
        }

        public async Task OnGet()
        {
            List<User> users = await _userService.GetAllAsync();

            foreach (var user in users)
            {
                Console.WriteLine($"User: {user.Id}, {user.FirstName} {user.LastName}");
            }

            Users = users;
        }
    }
}