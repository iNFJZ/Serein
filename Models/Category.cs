using System;
using System.Collections.Generic;

namespace Sereni.Models;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<CandleCategory> CandleCategories { get; set; } = new List<CandleCategory>();
}
