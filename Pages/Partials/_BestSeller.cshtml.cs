using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Serein.Models;

namespace Serein.Pages.Partials
{
    public class _BestSellerModel : PageModel
    {
        private readonly SereinContext _context;
        public _BestSellerModel(SereinContext context)
        {
            _context = context;
        }
        public IList<Candle> BestSellingCandles { get; set; } = new List<Candle>();
        public async Task OnGetAsync()
        {
            BestSellingCandles = await _context.Candles
                .Where(c => c.AverageRating.HasValue)
                .OrderByDescending(c => c.AverageRating) 
                .Take(5)
                .ToListAsync();
        }
    }
}
