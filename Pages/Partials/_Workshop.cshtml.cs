using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Serein.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Serein.Pages.Partials
{
    public class _WorkshopModel : PageModel
    {
        private readonly SereinContext _context;

        public _WorkshopModel(SereinContext context)
        {
            _context = context;
        }

        public List<RegisterWorkshop> RegisterWorkshops { get; set; } = new List<RegisterWorkshop>();

        public async Task OnGetAsync()
        {
            RegisterWorkshops = await _context.RegisterWorkshops.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var fullName = Request.Form["FullName"];
            var phoneNumber = Request.Form["PhoneNumber"];
            var email = User.FindFirst(System.Security.Claims.ClaimTypes.Email)?.Value;
            var workshopId = int.Parse(Request.Form["WorkshopId"]);
            var notes = Request.Form["Notes"];
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;

            // Kiểm tra các giá trị UserId và Email
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(userIdClaim))
            {
                ModelState.AddModelError(string.Empty, "User information is missing.");
                return Page();
            }

            // Khai báo biến userId ngoài scope của int.TryParse
            int userId;
            if (!int.TryParse(userIdClaim, out userId) || userId <= 0)
            {
                ModelState.AddModelError(string.Empty, "Invalid User ID.");
                return Page();
            }

            if (workshopId <= 0)
            {
                ModelState.AddModelError(string.Empty, "Invalid Workshop selection.");
                return Page();
            }

            // Tạo đối tượng Workshop
            var workshop = new Workshop
            {
                WorkshopId = workshopId,
                UserId = userId,
                Email = email,
                FullName = fullName,
                PhoneNumber = phoneNumber,
                Notes = notes,
                RegistrationDate = DateTime.Now
            };

            // Kiểm tra ModelState trước khi thêm
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Thêm workshop vào DbContext
                _context.Workshops.Add(workshop);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while saving data: " + ex.Message);
                return Page();
            }
        }

    }
}
