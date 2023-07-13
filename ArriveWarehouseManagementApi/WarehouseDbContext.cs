using ArriveWarehouseManagementApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ArriveWarehouseManagementApi
{
    public class WarehouseDbContext : DbContext
    {
        public WarehouseDbContext(DbContextOptions<WarehouseDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
