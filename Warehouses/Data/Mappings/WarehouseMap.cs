using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Warehouses.Models;

namespace Warehouses.Data.Mappings;

public class WarehouseMap : IEntityTypeConfiguration<Warehouse>
{
    public void Configure(EntityTypeBuilder<Warehouse> builder)
    {
        builder.ToTable("Warehouses");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .HasColumnName("Id")
            .ValueGeneratedOnAdd()
            .IsRequired();
        
        builder.Property(x => x.Name)
            .HasColumnName("Name")
            .HasColumnType("VARCHAR")
            .HasMaxLength(100)
            .IsRequired();

        builder.HasMany(x => x.Products)
            .WithMany(x => x.Warehouses)
            .UsingEntity<Dictionary<string, object>>(
                "WarehouseProduct",
                product => product.HasOne<Product>()
                    .WithMany()
                    .HasForeignKey("ProductId")
                    .HasConstraintName("FK_WarehouseProduct_ProductId")
                    .OnDelete(DeleteBehavior.Cascade),
                warehouse => warehouse.HasOne<Warehouse>()
                    .WithMany()
                    .HasForeignKey("WarehouseId")
                    .HasConstraintName("FK_WarehouseProduct_WarehouseId")
                );

    }
}