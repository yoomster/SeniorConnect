using CoreDomain.Users;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.DataAccesLibrary;
using SeniorConnect.Domain.Contracts;

namespace SeniorConnect.WebApp.Pages.UserPages
{
    public class AllUsersModel : PageModel
    {
        private readonly IUserRepository _userRepository;
        public List<User> AllUsers { get; set; }

        public AllUsersModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void OnGet()
        {
            List<User> users = _userRepository.GetUsers();

            foreach (var user in users)
            {
                Console.WriteLine($"User: {user.FirstName} {user.LastName}");
            }
            AllUsers = users;
        }
    }
}