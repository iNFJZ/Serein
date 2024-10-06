using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sereni.Models;
using System.ComponentModel.DataAnnotations;

namespace Sereni.Pages.Views.Account
{
    public class ResetPasswordModel : PageModel
    {
        private readonly SereniContext _context;

        public ResetPasswordModel(SereniContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InputModel Input { get; set; }
        [BindProperty]
        public string Token { get; set; }

        public class InputModel
        {
            [Required]
            [StringLength(255, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 255 characters.")]
            public string NewPassword { get; set; }

            [Required]
            [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task<IActionResult> OnGetAsync(string token)
        {
            if (string.IsNullOrEmpty(token))
            {
                return RedirectToPage("Login"); // Redirect to login if no token is provided.
            }

            // Store the token for the form submission.
            Token = token;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.PasswordResetToken == Token);

            if (user == null || user.PasswordResetSentAt == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid or expired token.");
                return Page();
            }

            // Check if the token has expired (valid for 30 minutes)
            var expirationTime = user.PasswordResetSentAt.Value.AddMinutes(30);
            if (DateTime.UtcNow > expirationTime)
            {
                ModelState.AddModelError(string.Empty, "Token has expired.");
                return Page();
            }

            // Update the user's password
            user.Password = BCrypt.Net.BCrypt.HashPassword(Input.NewPassword);
            user.PasswordResetToken = string.Empty; // Clear the token after successful reset
            user.PasswordResetSentAt = null; // Clear the reset sent time
            await _context.SaveChangesAsync();

            return RedirectToPage("Login", new { Message = "Your password has been reset. You can now log in." });
        }
    }
}
