using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sereni.Models;
using System;
using System.Threading.Tasks;

namespace Sereni.Pages.Views.Account
{
    public class VerifyAccountModel : PageModel
    {
        private readonly SereniContext _context;

        public VerifyAccountModel(SereniContext context)
        {
            _context = context;
        }

        public bool IsVerified { get; set; }

        public async Task<IActionResult> OnGetAsync(string code)
        {
            if (string.IsNullOrEmpty(code))
            {
                return RedirectToPage("Login"); // Chuyển hướng đến trang đăng nhập nếu không có mã
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.VerificationCode == code);

            if (user == null)
            {
                IsVerified = false;
                return Page();
            }

            // Kiểm tra thời gian hết hạn
            var expirationTime = user.VerificationSentAt.Value.AddMinutes(30);
            if (user.IsVerified || DateTime.UtcNow.AddHours(7) > expirationTime) // Chuyển đổi sang UTC+7
            {
                IsVerified = false;
                return Page();
            }

            // Đánh dấu tài khoản là đã được xác thực
            user.IsVerified = true;
            await _context.SaveChangesAsync();
            IsVerified = true;

            return RedirectToPage("Login", new { Message = "Your account has been verified. You can now log in." });
        }
    }
}
