using CoreDomain.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.DataAccesLibrary;

namespace SeniorConnect.WebApp.Pages.UserPages
{
    public class AllUsersModel : PageModel
    {
        private readonly DataAccess _dataAccess;
        private readonly UserRepository _userRepository;


        public List<User> Users { get; set; } = new List<User>();

        public AllUsersModel(DataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        public void OnGet()
        {
            Users = _userRepository.GetAllUsersFromDB();
        }
    }
}