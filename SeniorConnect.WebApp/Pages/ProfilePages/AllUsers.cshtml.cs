using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.Domain;

namespace SeniorConnect.WebApp.Pages.ProfilePages
{
    public class AllUsersModel : PageModel
    {
        private readonly IUserRepository _userRepository;
        public List<User> AllUsers { get; set; }

        public AllUsersModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task OnGet()
        {
            List<User> users = await _userRepository.GetAllUserAsync();

            foreach (var user in users)
            {
                Console.WriteLine($"User: {user.Id}, {user.FirstName} {user.LastName}");
            }

            AllUsers = users;
        }
    }
}