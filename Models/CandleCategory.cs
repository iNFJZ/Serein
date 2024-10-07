using System;
using System.Collections.Generic;

namespace Serein.Models;

public partial class CandleCategory
{
    public int CandleCategoryId { get; set; }

    public int? CandleId { get; set; }

    public int? CategoryId { get; set; }

    public virtual Candle? Candle { get; set; }

    public virtual Category? Category { get; set; }
}
