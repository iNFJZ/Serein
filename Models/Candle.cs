using System;
using System.Collections.Generic;

namespace Sereni.Models;

public partial class Candle
{
    public int CandleId { get; set; }

    public string? CandleName { get; set; }

    public string? Description { get; set; }

    public decimal? Price { get; set; }

    public string? BaseColor { get; set; }

    public string? Size { get; set; }

    public string? Fragrance { get; set; }

    public int? StockQuantity { get; set; }

    public decimal? OriginalPrice { get; set; }

    public decimal? SalePrice { get; set; }

    public string? ImageUrl { get; set; }

    public string? HoverImageUrl { get; set; }

    public virtual ICollection<CandleCategory> CandleCategories { get; set; } = new List<CandleCategory>();

    public virtual ICollection<Customization> Customizations { get; set; } = new List<Customization>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();

    public virtual ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();
}
