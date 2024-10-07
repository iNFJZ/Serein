using System;
using System.Collections.Generic;

namespace Serein.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Address { get; set; }

    public string? Role { get; set; }

    public string? AvatarUrl { get; set; }

    public bool IsVerified { get; set; }

    public string? VerificationCode { get; set; }

    public DateTime? VerificationSentAt { get; set; }

    public DateTime? PasswordResetSentAt { get; set; }

    public string? PasswordResetToken { get; set; }

    public virtual ICollection<Customization> Customizations { get; set; } = new List<Customization>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();

    public virtual ICollection<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();

    public virtual ICollection<Wishlist> Wishlists { get; set; } = new List<Wishlist>();

    public static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}
