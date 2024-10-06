using System;
using System.Collections.Generic;

namespace Sereni.Models;

public partial class Shipping
{
    public int ShippingId { get; set; }

    public int? OrderId { get; set; }

    public string? ShippingAddress { get; set; }

    public string? ShippingMethod { get; set; }

    public decimal? ShippingCost { get; set; }

    public string? TrackingNumber { get; set; }

    public DateTime? ShippedDate { get; set; }

    public virtual Order? Order { get; set; }
}
