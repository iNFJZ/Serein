using System;
using System.Collections.Generic;

namespace Sereni.Models;

public partial class Customization
{
    public int CustomizationId { get; set; }

    public int? UserId { get; set; }

    public int? CandleId { get; set; }

    public string? CustomColor { get; set; }

    public string? CustomText { get; set; }

    public string? CustomImage { get; set; }

    public string? CustomSticker { get; set; }

    public string? PreviewImage { get; set; }

    public virtual Candle? Candle { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();

    public virtual User? User { get; set; }
}
