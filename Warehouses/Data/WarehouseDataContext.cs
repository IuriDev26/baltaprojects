using Microsoft.EntityFrameworkCore;
using Warehouses.Data.Mappings;
using Warehouses.Models;

namespace Warehouses.Data;

public class WarehouseDataContext : DbContext
{
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

        optionsBuilder.UseSqlServer("User ID=sa;Password=Iuricrbtyuio123@#;Database=Warehouse;TrustServerCertificate=true");

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductMap());
        modelBuilder.ApplyConfiguration(new WarehouseMap());
    }
}