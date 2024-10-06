using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Sereni.Pages.Partials
{
    public class _WorkshopModel : PageModel
    {
        private readonly EmailService _emailService;

        public _WorkshopModel(EmailService emailService)
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

        public IActionResult OnPost(string Name, string Phone, string Email, string Workshop)
        {
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
            var subject = "C?m ?n b?n ?� ??ng k�!";
            var body = $"Ch�o {Name},<br><br>C?m ?n b?n ?� ??ng k� tham gia workshop {Workshop}. Ch�ng t�i s? li�n l?c v?i b?n s?m nh?t c� th?.<br><br>Tr�n tr?ng,<br>??i ng? Sereni";

            try
            {
                _emailService.SendEmail(Email, subject, body);
                Console.WriteLine("Email sent successfully.");
            }
            catch (Exception ex)
            {
                // Ghi l?i l?i ho?c x? l� th�ng b�o l?i
                Console.WriteLine($"L?i khi g?i email: {ex.Message}");
                ModelState.AddModelError(string.Empty, "C� l?i x?y ra khi g?i email. Vui l�ng th? l?i.");
                return Page();
            }

            return RedirectToPage("/Index");
        }

    }

}
