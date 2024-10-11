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
        public int WishlistCount { get; set; }
        public int CartCount { get; set; }
        public List<CartItemViewModel> CartItems { get; set; } = new List<CartItemViewModel>();
        public List<WishlistItemViewModel> WishlistItems { get; set; } = new List<WishlistItemViewModel>();
        public decimal CartTotal { get; set; }

        public async Task OnGetAsync()
        {
            Candles = await GetCandleListAsync();
            await LoadWishlistAndCartDataAsync();
        }

        private async Task<List<Candle>> GetCandleListAsync()
        {
            return await _context.Candles.ToListAsync();
        }

        private async Task LoadWishlistAndCartDataAsync()
        {
            // This is where you would load your wishlist and cart data
            // For example:
            // WishlistCount = await _context.WishlistItems.CountAsync();
            // CartItems = await _context.CartItems.ToListAsync();
            // CartCount = CartItems.Sum(item => item.Quantity);
            // CartTotal = CartItems.Sum(item => item.Price * item.Quantity);
        }
    }

    public class CartItemViewModel
    {
        public string CandleName { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }

    public class WishlistItemViewModel
    {
        public string CandleName { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
    }
}
