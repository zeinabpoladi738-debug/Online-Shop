using Microsoft.EntityFrameworkCore;
using Shop.Domain.Entities;

namespace Shop.Infrastructure.Data;

public class ShopDbContext : DbContext
{
    public ShopDbContext(DbContextOptions<ShopDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }

    public DbSet<ShoppingCart> ShoppingCarts { get; set; }

    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    public DbSet<Order> Orders { get; set; }

    public DbSet<OrderItem> OrderItems { get; set; }
    public DbSet<User> Tbl_Users { get; set; }      

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // ShoppingCartItem -> Product
        modelBuilder.Entity<ShoppingCartItem>()
            .HasOne(x => x.Product)
            .WithMany(x => x.ShoppingCartItems)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        // ShoppingCartItem -> ShoppingCart
        modelBuilder.Entity<ShoppingCartItem>()
            .HasOne(x => x.ShoppingCart)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.ShoppingCartId)
            .OnDelete(DeleteBehavior.Cascade);

        // Order -> ShoppingCart
        modelBuilder.Entity<Order>()
            .HasOne(x => x.Cart)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.CartId)
            .OnDelete(DeleteBehavior.Restrict);

        // Order -> OrderItems
        modelBuilder.Entity<Order>()
            .HasMany(x => x.Items)
            .WithOne(x => x.Order)
            .HasForeignKey(x => x.OrderId)
            .OnDelete(DeleteBehavior.Cascade);

        // OrderItem -> Product
        modelBuilder.Entity<OrderItem>()
            .HasOne(x => x.Product)
            .WithMany(x => x.OrderItems)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}