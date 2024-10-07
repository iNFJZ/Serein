using System;
using System.Collections.Generic;

namespace Serein.Models;

public partial class ShoppingCart
{
    public int CartId { get; set; }

    public int? UserId { get; set; }

    public int? CandleId { get; set; }

    public int? CustomizationId { get; set; }

    public int? Quantity { get; set; }

    public virtual Candle? Candle { get; set; }

    public virtual Customization? Customization { get; set; }

    public virtual User? User { get; set; }
}
