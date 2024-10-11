using System;
using System.Collections.Generic;

namespace Serein.Models;

public partial class Workshop
{
    public int RegistrationId { get; set; }

    public int WorkshopId { get; set; }

    public int UserId { get; set; }

    public DateTime RegistrationDate { get; set; }

    public string Email { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string PhoneNumber { get; set; } = null!;

    public string? PaymentStatus { get; set; }

    public string? Notes { get; set; }

    public virtual User User { get; set; } = null!;

    public virtual RegisterWorkshop WorkshopNavigation { get; set; } = null!;
}
