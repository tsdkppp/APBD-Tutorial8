using Tutorial8.Repositories;
using Tutorial8.Services;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "WarehouseAPI", Version = "v1" });
});


builder.Services.AddScoped<IProductRepository, SqlProductRepository>();
builder.Services.AddScoped<IWarehouseRepository, SqlWarehouseRepository>();
builder.Services.AddScoped<IOrderRepository, SqlOrderRepository>();
builder.Services.AddScoped<IProductWarehouseRepository, SqlProductWarehouseRepository>();
builder.Services.AddScoped<IWarehouseService, WarehouseService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => {
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WarehouseAPI V1");
});

app.UseHttpsRedirection();
app.MapControllers();

app.Run();