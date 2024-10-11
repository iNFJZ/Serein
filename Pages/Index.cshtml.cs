using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Serein.Models;
using Serein.Pages.Partials;
namespace Serein.Pages
{
    [Authorize]
    public class IndexModel : PageModel  
    {
        public _HeaderModel HeaderModel { get; set; }
        public _WorkshopModel WorkshopModel { get; set; }
        public _FeedbackModel FeedbackModel { get; set; }
        public _ProductModel ProductModel { get; set; }
        public _GiftboxModel GiftboxModel { get; set; }
        public _BestSellerModel BestSellerModel { get; set; }
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
            GiftboxModel = new _GiftboxModel(new SereinContext());
            await GiftboxModel.OnGetAsync();
            BestSellerModel = new _BestSellerModel(new SereinContext());
            await BestSellerModel.OnGetAsync();
            FeedbackModel = new _FeedbackModel(new SereinContext());
            await FeedbackModel.OnGetAsync();
            WorkshopModel = new _WorkshopModel(new SereinContext());
            await WorkshopModel.OnGetAsync();
            HeaderModel = new _HeaderModel(new SereinContext());
            await HeaderModel.OnGetAsync();
        }
    }
}
