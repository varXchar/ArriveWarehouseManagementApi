using ArriveWarehouseManagementApi.Models;

namespace ArriveWarehouseManagementApi.Repositories
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }

        void Add<EntityType>(EntityType entityType);

        Task SaveChangesAsync();
    }

    public class ProductRepository : IProductRepository
    {
        private readonly WarehouseDbContext _db;

        public ProductRepository(WarehouseDbContext db)
        {
            _db = db;
        }

        public IQueryable<Product> Products => _db.Products;

        public void Add<EntityType>(EntityType entity)
        {
            _db.Add(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
