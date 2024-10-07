using System;
using System.Collections.Generic;

namespace Sereni.Models;

public partial class Review
{
    public int ReviewId { get; set; }

    public int UserId { get; set; }

    public int CandleId { get; set; }

    public int Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? ReviewDate { get; set; }
    public bool IsVerifiedPurchase { get; set; }
    public virtual Candle? Candle { get; set; }
    public virtual User? User { get; set; }

}
