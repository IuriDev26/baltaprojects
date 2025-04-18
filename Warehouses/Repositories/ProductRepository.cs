using Warehouses.Data;
using Warehouses.Models;

namespace Warehouses.Repositories;

public class ProductRepository : Repository<Product>
{
    public ProductRepository(WarehouseDataContext context) : base(context)
    {
    }
}