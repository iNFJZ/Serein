using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Sereni.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sereni.Pages.Partials
{
    public class _ProductModel : PageModel
    {
        private readonly SereniContext _context;

        public _ProductModel(SereniContext context)
        {
            _context = context;
        }

        public IList<Candle> Candles { get; set; } = new List<Candle>();

        public async Task OnGetAsync()
        {
            var candles = await _context.Candles.Include(c => c.Reviews).ToListAsync();
            foreach (var candle in candles)
            {
                if (candle.Reviews.Count > 0)
                {
                    candle.AverageRating = (float?)candle.Reviews.Average(r => r.Rating);
                    candle.StarCount = candle.Reviews.Count;
                }
            }

            Candles = candles;
        }
    }
}
