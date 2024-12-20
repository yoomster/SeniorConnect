using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SeniorConnect.WebApp.Models;
using SeniorConnect.DataAccesLibrary;
using CoreDomain.Users;
using SeniorConnect.Domain.Contracts;
using System.Reflection;
using CoreDomain;
using SeniorConnect.Domain.Services;

namespace SeniorConnect.WebApp.Pages.IdentityAccessManagement
{
    public class RegisterModel : PageModel
    {
        private readonly IUserRepository _userRepository;
        private readonly IAddressRepository _addressRepository;

        [BindProperty]
        public UserUI User { get; set; }

        public RegisterModel(IUserRepository userRepository, IAddressRepository addressRepository)
        {
            _userRepository = userRepository;
            _addressRepository = addressRepository;
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
                //verander dit naar een CreateAddress method uit domein!
                var newAddress = new Address
                {
                    StreetName = User.StreetName,
                    HouseNumber = User.HouseNumber,
                    Zipcode = User.Zipcode,
                    City = User.City,
                    Country = User.Country,
                };

                var addressId = await _addressRepository.SaveAddressToDBAsync(newAddress);

                //verander dit naar een CreateUser method uit domein!
                var newUser = new User
                {
                    FirstName = User.FirstName,
                    LastName = User.LastName,
                    Email = User.Email,
                    Password = User.Password,
                    DateOfBirth = DateOnly.FromDateTime(User.DateOfBirth),
                    Gender = User.Gender,
                    Origin = User.Origin,
                    DateOfRegistration = DateOnly.FromDateTime(DateTime.Now),
                    AddressId = addressId
                };

                UserService.CreateUser(newUser);

                //this be done by domain instead here
                await _userRepository.SaveToDBAsync(newUser);


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
    }
}

