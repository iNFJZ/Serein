using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serein.Models;
using Serein.Pages.Partials;
namespace Serein.Pages
{
    [Authorize]
    public class IndexModel : PageModel  
    {
        public _ProductModel ProductModel { get; set; }
        private readonly ILogger<IndexModel> _logger;
        private readonly SereinContext _context;
        public IndexModel(ILogger<IndexModel> logger, SereinContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task OnGetAsync()
        {
            ProductModel = new _ProductModel(new SereinContext());
            await ProductModel.OnGetAsync();
        }
    }
}
