using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sereni.Models;
using Sereni.Services;
using System.ComponentModel.DataAnnotations;

namespace Sereni.Pages.Views.Account
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly SereniContext _context;
        private readonly EmailService _emailService;

        public ForgotPasswordModel(SereniContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Email is required.")]
            [EmailAddress(ErrorMessage = "Invalid email format.")]
            public string Email { get; set; }
        }

        public void OnGet() { }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == Input.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid email address.");
                return Page();
            }

            user.PasswordResetToken = Guid.NewGuid().ToString();
            user.PasswordResetSentAt = DateTime.UtcNow.AddHours(7);
            await _context.SaveChangesAsync();

            // Create password reset link
            var resetLink = Url.Page(
                            "/Views/Account/ResetPassword",
                            null,
                            new { token = user.PasswordResetToken },
                            Request.Scheme);

            await _emailService.SendEmailAsync(Input.Email, "Reset your password",
                $"Please reset your password by clicking this link: <a href='{resetLink}'>Reset Password</a>");


            return RedirectToPage("ForgotPasswordConfirmation");
        }
    }
}
