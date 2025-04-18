using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using Warehouses.Data;
using Warehouses.Models;
using Warehouses.Repositories;

namespace Warehouses.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WarehouseController : ControllerBase
{
   private readonly WarehouseRepository _repository;

   public WarehouseController(WarehouseDataContext context)
   {
      _repository = new WarehouseRepository(context);
   }
   
   [HttpGet("")]
   public async Task<IActionResult> GetWarehousesAsync()
   {

      var warehouses = await _repository.GetAllAsync();

      return Ok(warehouses);

   }

   [HttpPost()]
   public async Task<IActionResult> AddWarehouseAsync([FromBody] Warehouse warehouse)
   {
      await _repository.AddAsync(warehouse);
      return Ok();
   }
   
   
   
}