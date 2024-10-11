using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Serein.Models;

namespace Serein.Pages.Partials
{
    public class _FeedbackModel : PageModel
    {
        private readonly SereinContext _context;
        public _FeedbackModel(SereinContext context)
        {
            _context = context;
        }
        public IList<Review> Reviews { get; set; } = new List<Review>();

        public async Task OnGetAsync()
        {
            Reviews = await _context.Reviews
                .Include(r => r.User)
                .Include(r => r.Candle)
                .ToListAsync();
        }
    }
}
