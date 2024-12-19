using CoreDomain.Users;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.DataAccesLibrary;
using SeniorConnect.Domain.Contracts;

namespace SeniorConnect.WebApp.Pages.UserPages
{
    public class AllUsersModel : PageModel
    {
        private readonly IActivityRepository _userRepository;
        public List<User> AllUsers { get; set; }

        public AllUsersModel(IActivityRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task OnGet()
        {
            List<User> users = await _userRepository.GetUsersAsync();

            foreach (var user in users)
            {
                Console.WriteLine($"User: {user.FirstName} {user.LastName}");
            }

            AllUsers = users;
        }
    }
}