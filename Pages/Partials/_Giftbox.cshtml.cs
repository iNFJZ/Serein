using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Serein.Models;

namespace Serein.Pages.Partials
{
    public class _GiftboxModel : PageModel
    {
        private readonly SereinContext _context;
        public _GiftboxModel(SereinContext context)
        {
            _context = context;
        }
        public IList<GiftBox> GiftBoxes { get; set; } = new List<GiftBox>();

        public async Task OnGetAsync()
        {
            GiftBoxes = await _context.GiftBoxes.ToListAsync();
        }
    }
}
