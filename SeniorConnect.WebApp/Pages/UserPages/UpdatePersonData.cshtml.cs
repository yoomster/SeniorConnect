using CoreDomain.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.DataAccesLibrary;
using SeniorConnect.Domain.Contracts;
using SeniorConnect.WebApp.Models;

namespace SeniorConnect.WebApp.Pages.UserPages
{
    public class UpdatePersonDataModel : PageModel
    {
        private readonly IUserRepository _userRepository;


        [BindProperty]
        public UserFormModel UserFormModel { get; set; }


        public UpdatePersonDataModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public ActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var userToUpdate = new User
                {
                    Id = UserFormModel.Id,
                    FirstName = UserFormModel.FirstName,
                    LastName = UserFormModel.LastName,
                    Email = UserFormModel.Email,
                    Password = UserFormModel.Password, // Hashing is handled in repository
                    DateOfBirth = UserFormModel.DateOfBirth,
                    Gender = UserFormModel.Gender,
                    Iban = UserFormModel.Iban,
                };

                _userRepository.UpdateUser(userToUpdate);

                TempData["SuccessMessage"] = "User updated successfully!";
                return RedirectToPage("Profile");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while updating the user. Please try again.");
                Console.WriteLine("Error updating user: " + ex.Message);
                return Page();
            }
        }

    }
}
