using System;
using System.Collections.Generic;

namespace Sereni.Models;

public partial class Coupon
{
    public int CouponId { get; set; }

    public string? Code { get; set; }

    public decimal? Discount { get; set; }

    public DateOnly? ExpiryDate { get; set; }

    public int? UsageLimit { get; set; }
}
