namespace Warehouses.Models;

public class Warehouse : BaseEntity
{
    public string Name { get; set; }
    public List<Product> Products { get; set; } = new();
}