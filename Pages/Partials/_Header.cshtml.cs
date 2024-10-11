using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Serein.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Serein.Pages.Partials
{
    public class _HeaderModel : PageModel
    {
        private readonly SereinContext _context;

        public _HeaderModel(SereinContext context)
        {
            _context = context;
        }

        public List<Candle> Candles { get; set; } = new List<Candle>();

        public async Task OnGetAsync() 
        {
            Candles = await GetCandleListAsync();
        }

        private async Task<List<Candle>> GetCandleListAsync() 
        {
            return await _context.Candles.ToListAsync();
        }
    }
}
