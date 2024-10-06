using System;
using System.Collections.Generic;

namespace Sereni.Models;

public partial class Wishlist
{
    public int WishlistId { get; set; }

    public int? UserId { get; set; }

    public int? CandleId { get; set; }

    public DateTime? AddedDate { get; set; }

    public virtual Candle? Candle { get; set; }

    public virtual User? User { get; set; }
}
