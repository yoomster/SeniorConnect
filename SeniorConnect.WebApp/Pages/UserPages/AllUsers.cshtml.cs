using CoreDomain.Users;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.DataAccesLibrary;

namespace SeniorConnect.WebApp.Pages.UserPages
{
    public class AllUsersModel : PageModel
    {
        private readonly UserRepository _userRepository;
        public List<User> AllUsers { get; set; }

        public AllUsersModel(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void OnGet()
        {
            List<User> users = _userRepository.GetUsersV2();

            foreach (var user in users)
            {
                Console.WriteLine($"User: {user.FirstName} {user.LastName}");
            }
            AllUsers = users;
        }
    }
}