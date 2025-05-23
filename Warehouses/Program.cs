using Warehouses.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<WarehouseDataContext>();

var app = builder.Build();

app.MapControllers();

app.Run();
