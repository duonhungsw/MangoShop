using Core.Interfaces;
using Mango.Service.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Mango.Service.ProductAPI.Repository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<IEnumerable<Product>> ListAsync();
        IQueryable<Product> ListAsQueryAsync();
        Task<int> CountAsync();
        Task<List<Product>> PaginationAsync(int page, int pageSize);
    }
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductDbContext context) : base(context)
        {
        }
        public async Task<int> CountAsync() => await _context.Products.CountAsync();
        public  async Task<IEnumerable<Product>> ListAsync() => await _context.Products.ToListAsync();
        public IQueryable<Product> ListAsQueryAsync()
            => _context.Products.AsQueryable();

        public async Task<List<Product>> PaginationAsync(int page, int pageSize)
        {
          return  await _context.Products
                                 .Skip((page - 1) * pageSize)
                                 .Take(pageSize)
                                 .ToListAsync();
        }
    }
}
