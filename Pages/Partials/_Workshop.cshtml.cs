using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serein.Services.IServices;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Serein.Pages.Partials
{
    public class _WorkshopModel : PageModel
    {
        private readonly IEmailService _emailService;

        public _WorkshopModel(IEmailService emailService) 
        {
            _emailService = emailService;
        }

        [BindProperty]
        public string Name { get; set; }

        [BindProperty]
        public string Phone { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string Workshop { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync() // Thay ??i thành Task<IActionResult>
        {
            Name = Request.Form["Name"];
            Workshop = Request.Form["Workshop"];
            Phone = Request.Form["Phone"];
            Email = Request.Form["Email"];
            if (!ModelState.IsValid)
            {
                // Log the model state errors
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Model Error: {error.ErrorMessage}");
                }
                return Page();
            }

            // G?i email c?m ?n
            var subject = "C?m ?n b?n ?ã ??ng ký!";
            var body = $"Chào {Name},<br><br>C?m ?n b?n ?ã ??ng ký tham gia workshop {Workshop}. Chúng tôi s? liên l?c v?i b?n s?m nh?t có th?.<br><br>Trân tr?ng,<br>??i ng? Serein";

            try
            {
                await _emailService.SendEmailAsync(Email, subject, body); // S? d?ng await cho ph??ng th?c b?t ??ng b?
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                // Ghi l?i l?i ho?c x? lý thông báo l?i
                Console.WriteLine($"L?i khi g?i email: {ex.Message}");
                ModelState.AddModelError(string.Empty, "Có l?i x?y ra khi g?i email. Vui lòng th? l?i.");
                return Page();
            }

            return RedirectToPage("/Index");
        }
    }
}
