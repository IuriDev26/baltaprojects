using Warehouses.Data;
using Warehouses.Models;

namespace Warehouses.Repositories;

public class WarehouseRepository : Repository<Warehouse>
{
    public WarehouseRepository(WarehouseDataContext context) : base(context)
    {
    }
}