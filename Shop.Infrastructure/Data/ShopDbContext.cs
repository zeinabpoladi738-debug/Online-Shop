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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ShoppingCartItem>()
            .HasOne(x => x.Product)
            .WithMany(x => x.ShoppingCartItems)
            .HasForeignKey(x => x.ProductId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ShoppingCartItem>()
            .HasOne(x => x.ShoppingCart)
            .WithMany(x => x.Items)
            .HasForeignKey(x => x.ShoppingCartId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}