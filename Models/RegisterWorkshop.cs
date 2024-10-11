using System;
using System.Collections.Generic;

namespace Serein.Models;

public partial class RegisterWorkshop
{
    public int WorkshopId { get; set; }

    public string WorkshopName { get; set; } = null!;

    public DateTime WorkshopDate { get; set; }

    public string WorkshopLocation { get; set; } = null!;

    public virtual ICollection<Workshop> Workshops { get; set; } = new List<Workshop>();
}
