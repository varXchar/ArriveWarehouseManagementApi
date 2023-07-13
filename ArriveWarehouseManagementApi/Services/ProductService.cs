using ArriveWarehouseManagementApi.Models;
using ArriveWarehouseManagementApi.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ArriveWarehouseManagementApi.Services
{
    public interface IProductService
    {
        Task<Result<Product>> CreateAsync(Product product);
        Task<Result<Product>> GetByIdAsync(int id);
        Task<Result<List<Product>>> GetAllAsync();
        Task<Result<Product>> UpdateAsync(Product product);
        Task<Result> DeleteAsync(int id);
    }
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) 
        {
            _productRepository = productRepository;
        }

        public async Task<Result<Product>> CreateAsync(Product product)
        {
            var result = new Result<Product>();
            if (product != null && product.CanCreate())
            {
                try
                {
                    // TODO: Check for duplicates

                    _productRepository.Add(product);
                    await _productRepository.SaveChangesAsync();
                    result.Value = product;
                }
                catch (Exception ex)
                {
                    // TODO: Add logging
                    result.Messages.Add(ex.Message);
                }
            }

            return result;
        }

        public async Task<Result<List<Product>>> GetAllAsync()
        {
            return new Result<List<Product>>()
            {
                Value = await _productRepository.Products.ToListAsync()
            };
        }

        public async Task<Result<Product>> GetByIdAsync(int id)
        {
            return new Result<Product>()
            {
                Value = await _productRepository.Products.FirstOrDefaultAsync(p => p.Id == id)
            };
        }

        public async Task<Result<Product>> UpdateAsync(Product product)
        {
            var result = new Result<Product>();
            if (product != null && product.CanCreate())
            {
                var existing = await _productRepository.Products.FirstOrDefaultAsync(p => p.Id == product.Id);
                if (existing != null)
                {
                    try
                    {
                        existing.Name = product.Name;
                        existing.Quantity = product.Quantity;
                        await _productRepository.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        // TODO: Add logging
                        result.Messages.Add(ex.Message);
                    }
                }
            }

            return result;
        }

        public async Task<Result> DeleteAsync(int id)
        {
            var result = new Result(true);

            var existing = await _productRepository.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (existing != null)
            {
                try
                {
                    existing.IsDeleted = true;
                    await _productRepository.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    // TODO: Add logging
                    result.Messages.Add(ex.Message);
                }
            }

            return result;
        }
    }
}
