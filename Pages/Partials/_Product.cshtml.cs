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
    public class _ProductModel : PageModel
    {
        private readonly SereinContext _context;

        public _ProductModel(SereinContext context)
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

        [HttpPost]
        public async Task<IActionResult> OnPostAddToCartAsync(int candleId, int? customizationId, int userId)
        {
            var existingCartItem = await _context.ShoppingCarts
                .FirstOrDefaultAsync(x => x.CandleId == candleId &&
                                           x.CustomizationId == customizationId &&
                                           x.UserId == userId);

            if (existingCartItem == null)
            {
                var newCartItem = new ShoppingCart
                {
                    CandleId = candleId,
                    CustomizationId = customizationId,
                    UserId = userId
                };

                _context.ShoppingCarts.Add(newCartItem);
                await _context.SaveChangesAsync();

                return RedirectToPage("/Index"); // Redirect về trang chính sau khi thêm
            }
            else
            {
                return RedirectToPage("/Index"); // Hoặc có thể hiển thị thông báo lỗi
            }
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAddToWishlistAsync(int candleId, int userId)
        {
            var existingWishlistItem = await _context.Wishlists
                .FirstOrDefaultAsync(x => x.CandleId == candleId &&
                                           x.UserId == userId);

            if (existingWishlistItem == null)
            {
                var newWishlistItem = new Wishlist
                {
                    CandleId = candleId,
                    UserId = userId,
                    AddedDate = DateTime.Now
                };

                _context.Wishlists.Add(newWishlistItem);
                await _context.SaveChangesAsync();

                return RedirectToPage("/Index"); // Redirect về trang chính sau khi thêm
            }
            else
            {
                return RedirectToPage("/Index"); // Hoặc có thể hiển thị thông báo lỗi
            }
        }
    }
}
