namespace Warehouses.Models;

public class Product : BaseEntity
{
    public string Description { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public List<Warehouse> Warehouses { get; set; }
}