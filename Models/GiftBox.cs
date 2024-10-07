using System;
using System.Collections.Generic;

namespace Serein.Models;

public partial class GiftBox
{
    public int GiftBoxId { get; set; }

    public string GiftBoxName { get; set; } = null!;

    public string ImageName { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Description { get; set; }

    public int StockQuantity { get; set; }

    public string ImageUrl { get; set; } = null!;

    public string? HoverImageUrl { get; set; }
}
