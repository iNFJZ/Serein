using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Serein.Models;

public partial class SereinContext : DbContext
{
    public SereinContext()
    {
    }

    public SereinContext(DbContextOptions<SereinContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Candle> Candles { get; set; }

    public virtual DbSet<CandleCategory> CandleCategories { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Coupon> Coupons { get; set; }

    public virtual DbSet<Customization> Customizations { get; set; }

    public virtual DbSet<GiftBox> GiftBoxes { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<Shipping> Shippings { get; set; }

    public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Wishlist> Wishlists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DB");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candle>(entity =>
        {
            entity.HasKey(e => e.CandleId).HasName("PK__Candles__502CC3C99B42687B");

            entity.Property(e => e.CandleId).HasColumnName("CandleID");
            entity.Property(e => e.AverageRating).HasDefaultValue(0.0);
            entity.Property(e => e.BaseColor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CandleName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Fragrance)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HoverImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.OriginalPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.SalePrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Size)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.StarCount).HasDefaultValue(0);
        });

        modelBuilder.Entity<CandleCategory>(entity =>
        {
            entity.HasKey(e => e.CandleCategoryId).HasName("PK__CandleCa__084580F952B43FB8");

            entity.Property(e => e.CandleCategoryId).HasColumnName("CandleCategoryID");
            entity.Property(e => e.CandleId).HasColumnName("CandleID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

            entity.HasOne(d => d.Candle).WithMany(p => p.CandleCategories)
                .HasForeignKey(d => d.CandleId)
                .HasConstraintName("FK__CandleCat__Candl__5535A963");

            entity.HasOne(d => d.Category).WithMany(p => p.CandleCategories)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__CandleCat__Categ__5629CD9C");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A2BBB31DB18");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasColumnType("text");
        });

        modelBuilder.Entity<Coupon>(entity =>
        {
            entity.HasKey(e => e.CouponId).HasName("PK__Coupons__384AF1DAC4DD2F8D");

            entity.HasIndex(e => e.Code, "UQ__Coupons__A25C5AA74D1A53FA").IsUnique();

            entity.Property(e => e.CouponId).HasColumnName("CouponID");
            entity.Property(e => e.Code)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Discount).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Customization>(entity =>
        {
            entity.HasKey(e => e.CustomizationId).HasName("PK__Customiz__6F38011C5F1B9742");

            entity.Property(e => e.CustomizationId).HasColumnName("CustomizationID");
            entity.Property(e => e.CandleId).HasColumnName("CandleID");
            entity.Property(e => e.CustomColor)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CustomImage)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CustomSticker)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.CustomText).HasColumnType("text");
            entity.Property(e => e.PreviewImage)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Candle).WithMany(p => p.Customizations)
                .HasForeignKey(d => d.CandleId)
                .HasConstraintName("FK__Customiza__Candl__571DF1D5");

            entity.HasOne(d => d.User).WithMany(p => p.Customizations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Customiza__UserI__5812160E");
        });

        modelBuilder.Entity<GiftBox>(entity =>
        {
            entity.HasKey(e => e.GiftBoxId).HasName("PK__GiftBoxe__7E109D4917BFBA1F");

            entity.Property(e => e.GiftBoxId).HasColumnName("GiftBoxID");
            entity.Property(e => e.GiftBoxName).HasMaxLength(255);
            entity.Property(e => e.HoverImageUrl).HasMaxLength(255);
            entity.Property(e => e.ImageName).HasMaxLength(255);
            entity.Property(e => e.ImageUrl).HasMaxLength(255);
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF2557853E");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Orders__UserID__5BE2A6F2");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D30C10BF6B1C");

            entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");
            entity.Property(e => e.CandleId).HasColumnName("CandleID");
            entity.Property(e => e.CustomizationId).HasColumnName("CustomizationID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Candle).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.CandleId)
                .HasConstraintName("FK__OrderDeta__Candl__59063A47");

            entity.HasOne(d => d.Customization).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.CustomizationId)
                .HasConstraintName("FK__OrderDeta__Custo__59FA5E80");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderDeta__Order__5AEE82B9");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A58C227CB09");

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.AmountPaid).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.PaymentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.PaymentMethod)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Payments__OrderI__5CD6CB2B");
        });

        modelBuilder.Entity<Review>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Reviews__74BC79AEC1EE04BA");

            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.CandleId).HasColumnName("CandleID");
            entity.Property(e => e.Comment).HasColumnType("text");
            entity.Property(e => e.IsVerifiedPurchase).HasDefaultValue(false);
            entity.Property(e => e.ReviewDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Candle).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.CandleId)
                .HasConstraintName("FK__Reviews__CandleI__5DCAEF64");

            entity.HasOne(d => d.User).WithMany(p => p.Reviews)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Reviews__UserID__5EBF139D");
        });

        modelBuilder.Entity<Shipping>(entity =>
        {
            entity.HasKey(e => e.ShippingId).HasName("PK__Shipping__5FACD46059627439");

            entity.ToTable("Shipping");

            entity.Property(e => e.ShippingId).HasColumnName("ShippingID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ShippedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.ShippingAddress).HasColumnType("text");
            entity.Property(e => e.ShippingCost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ShippingMethod)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TrackingNumber)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Order).WithMany(p => p.Shippings)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Shipping__OrderI__5FB337D6");
        });

        modelBuilder.Entity<ShoppingCart>(entity =>
        {
            entity.HasKey(e => e.CartId).HasName("PK__Shopping__51BCD7972EF4E029");

            entity.ToTable("ShoppingCart");

            entity.Property(e => e.CartId).HasColumnName("CartID");
            entity.Property(e => e.CandleId).HasColumnName("CandleID");
            entity.Property(e => e.CustomizationId).HasColumnName("CustomizationID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Candle).WithMany(p => p.ShoppingCarts)
                .HasForeignKey(d => d.CandleId)
                .HasConstraintName("FK__ShoppingC__Candl__60A75C0F");

            entity.HasOne(d => d.Customization).WithMany(p => p.ShoppingCarts)
                .HasForeignKey(d => d.CustomizationId)
                .HasConstraintName("FK__ShoppingC__Custo__619B8048");

            entity.HasOne(d => d.User).WithMany(p => p.ShoppingCarts)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__ShoppingC__UserI__628FA481");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC9475F7E0");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105345B91C645").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Address).HasColumnType("text");
            entity.Property(e => e.AvatarUrl)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PasswordResetSentAt).HasColumnType("datetime");
            entity.Property(e => e.PasswordResetToken).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.VerificationCode).HasMaxLength(255);
            entity.Property(e => e.VerificationSentAt).HasColumnType("datetime");
        });

        modelBuilder.Entity<Wishlist>(entity =>
        {
            entity.HasKey(e => e.WishlistId).HasName("PK__Wishlist__233189CB4055B6E9");

            entity.ToTable("Wishlist");

            entity.Property(e => e.WishlistId).HasColumnName("WishlistID");
            entity.Property(e => e.AddedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.CandleId).HasColumnName("CandleID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Candle).WithMany(p => p.Wishlists)
                .HasForeignKey(d => d.CandleId)
                .HasConstraintName("FK__Wishlist__Candle__6383C8BA");

            entity.HasOne(d => d.User).WithMany(p => p.Wishlists)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Wishlist__UserID__6477ECF3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
