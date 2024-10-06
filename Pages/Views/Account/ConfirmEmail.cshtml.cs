using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sereni.Models;
using System.Threading.Tasks;

namespace Sereni.Pages.Views.Account
{
    public class ConfirmEmailModel : PageModel
    {
        private readonly SereniContext _context;

        public ConfirmEmailModel(SereniContext context)
        {
            _context = context;
        }

        public string Message { get; set; }

        public async Task<IActionResult> OnGetAsync(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
            if (user == null)
            {
                Message = "Invalid email confirmation link.";
                return Page();
            }

            Message = "Your email has been confirmed successfully!";
            return Page();
        }
    }
}
