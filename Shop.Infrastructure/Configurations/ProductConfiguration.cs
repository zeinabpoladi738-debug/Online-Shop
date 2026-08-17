using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entities;

namespace Shop.Infrastructure.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
               .IsRequired()
               .HasMaxLength(200);

        builder.Property(x => x.Description)
               .HasMaxLength(1000);

        builder.Property(x => x.Price)
               .HasPrecision(18, 2);

        builder.Property(x => x.ImageUrl)
               .HasMaxLength(500);

        builder.Property(x => x.IsActive)
               .HasDefaultValue(true);
    }
}
