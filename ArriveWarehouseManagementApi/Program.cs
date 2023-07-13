using ArriveWarehouseManagementApi;
using ArriveWarehouseManagementApi.Repositories;
using ArriveWarehouseManagementApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// register db context
builder.Services.AddDbContext<WarehouseDbContext>(options => options.UseInMemoryDatabase("WarehouseDb"));

// register repository
builder.Services.AddTransient<IProductRepository, ProductRepository>();

// register service
builder.Services.AddTransient<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
