using CoreDomain;
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
        public UserFormModel User { get; set; }

        public UpdatePersonDataModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                User userToUpdate = new User
                {
                    Id = User.Id,
                    FirstName = User.FirstName,
                    LastName = User.LastName,
                    Email = User.Email,
                    Password = User.Password,
                    DateOfBirth = User.DateOfBirth,
                    Gender = User.Gender,
                    StreetName = User.StreetName,
                    Origin = User.Origin,
                    HouseNumber = User.HouseNumber,
                    Zipcode = User.Zipcode,
                    City = User.City,
                    Country = User.Country,
                };

                //await _userRepository.UpdateUserAsync(userToUpdate);

                TempData["SuccessMessage"] = "User and address updated successfully!";
                return RedirectToPage("Profile");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while updating data. Please try again.");
                Console.WriteLine("Error updating user or address: " + ex.Message);
                return Page();
            }
        }
    }
}
