using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sereni.Models;
using Sereni.Pages.Partials;
namespace Sereni.Pages
{
    [Authorize]
    public class IndexModel : PageModel  
    {
        public _ProductModel ProductModel { get; set; }
        private readonly ILogger<IndexModel> _logger;
        private readonly SereniContext _context;
        public IndexModel(ILogger<IndexModel> logger, SereniContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task OnGetAsync()
        {
            ProductModel = new _ProductModel(new SereniContext());
            await ProductModel.OnGetAsync();
        }
    }
}
