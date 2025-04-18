using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouses.Models;

namespace Warehouses.Data.Mappings;

public class ProductMap : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        
        builder.HasKey(x => x.Id);
        
        builder.Property( x => x.Id )
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder.Property(x => x.Description)
            .HasColumnName("Description")
            .HasColumnType("VARCHAR")
            .HasMaxLength(200)
            .IsRequired();
        
        builder.Property(x => x.Price)
            .HasColumnName("Price")
            .HasColumnType("DECIMAL")
            .IsRequired();
    }
}