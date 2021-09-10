using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ProductApp.DAL.Data.Repository.Interfaces;
using ProductApp.DAL.Models.Product;

namespace ProductApp.DAL.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductEntity>> GetAllProductAsync()
        {
           var products = await _context.ProductEntities.AsNoTracking().ToListAsync();

           return products;
        }

        public async Task<ProductsPerPageEntity> GetProductsPerPageAsync(int page, int pageSize)
        {
            var productsCount =  _context.ProductEntities.Count();
            var products = await _context.ProductEntities.AsNoTracking().Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            var result = new ProductsPerPageEntity()
            {
                Count = productsCount,
                ProductEntities = products
            };

            return result;
        }

        public async Task<IEnumerable<ProductEntity>> GetByNameAsync(string name)
        {
            var product = await _context.ProductEntities.Where(p => p.Name.StartsWith(name)).ToListAsync();

            return product;
        }

        public async Task CreateAsync(ProductEntity productEntity)
        {
            await _context.AddAsync(productEntity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _context.ProductEntities.FirstOrDefaultAsync(p => p.Id == id);

            if (product == null)
                return false;

            _context.ProductEntities.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task EditAsync(ProductEntity productEntity)
        {
            _context.ProductEntities.Update(productEntity);
            await _context.SaveChangesAsync();
        }
    }
}