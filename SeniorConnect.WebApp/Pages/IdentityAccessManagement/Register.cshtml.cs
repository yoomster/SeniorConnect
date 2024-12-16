using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.WebApp.Models;
using SeniorConnect.DataAccesLibrary;
using CoreDomain.Users;
using SeniorConnect.Domain.Contracts;
using System.Reflection;
using CoreDomain;

namespace SeniorConnect.WebApp.Pages.IdentityAccessManagement
{
    public class RegisterModel : PageModel
    {
        private readonly IUserRepository _userRepository;

        [BindProperty]
        public UserUI User { get; set; }

        public RegisterModel(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var newAddress = new Address
                {
                    StreetName = User.StreetName,
                    HouseNumber = User.HouseNumber,
                    Zipcode = User.Zipcode,
                    City = User.City,
                    Country = User.Country,
                };

                var addressId = await _addressRepository.SaveAddressToDBAsync(newAddress);

                var newUser = new User
                {
                    FirstName = User.FirstName,
                    LastName = User.LastName,
                    Email = User.Email,
                    Password = User.Password,
                    DateOfBirth = DateOnly.FromDateTime(User.DateOfBirth),
                    Gender = User.Gender,
                    Origin = User.Origin,
                    DateOfRegistration = DateTime.UtcNow,
                    AddressId = addressId

                };

                await _userRepository.SaveUserToDBAsync(newUser);


                TempData["SuccessMessage"] = "User registered successfully!";
                return RedirectToPage("Login");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error registering user: {ex.Message}");
                TempData["ErrorMessage"] = "An error occurred while registering. Please try again later.";
                return Page();
            }
        }