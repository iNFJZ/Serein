using System;
using System.Collections.Generic;

namespace Serein.Models;

public partial class OrderDetail
{
    public int OrderDetailId { get; set; }

    public int? OrderId { get; set; }

    public int? CandleId { get; set; }

    public int? CustomizationId { get; set; }

    public int? Quantity { get; set; }

    public decimal? Price { get; set; }

    public virtual Candle? Candle { get; set; }

    public virtual Customization? Customization { get; set; }

    public virtual Order? Order { get; set; }
}
