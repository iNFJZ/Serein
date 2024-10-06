using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sereni.Models;
using System.ComponentModel.DataAnnotations;

namespace Sereni.Pages.Views.Account
{
    public class RegisterModel : PageModel
    {
        private SereniContext _context;
        public RegisterModel(SereniContext context)
        {
            _context = context;
        }
        [BindProperty]
        public InputModel Input { get; set; }

        public string StatusMessage { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Full Name is required.")]
            public string FullName { get; set; }

            [Required(ErrorMessage = "Email is required.")]
            [EmailAddress(ErrorMessage = "Invalid email format.")]
            [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Email must be valid.")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Phone Number is required.")]
            public string PhoneNumber { get; set; }

            [Required(ErrorMessage = "Password is required.")]
            [StringLength(255, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 255 characters.")]
            public string Password { get; set; }
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

            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == Input.Email);
            if (existingUser != null)
            {
                ModelState.AddModelError("Input.Email", "Email is already in use.");
            }

            var validDomains = new[] { "gmail.com", "fpt.edu.vn", "yahoo.com", "outlook.com" };
            var emailDomain = Input.Email.Split('@').Last();

            if (!validDomains.Contains(emailDomain))
            {
                ModelState.AddModelError("Input.Email", "Email is not allowed.");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = new User
                {
                    FullName = Input.FullName,
                    Email = Input.Email,
                    PhoneNumber = Input.PhoneNumber,
                    Password = BCrypt.Net.BCrypt.HashPassword(Input.Password),
                    Role = "customer"
                };

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

            return RedirectToPage("Login");
        }
        }
}