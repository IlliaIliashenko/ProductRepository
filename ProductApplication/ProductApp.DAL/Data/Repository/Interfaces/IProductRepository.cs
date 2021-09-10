using System.Collections.Generic;
using System.Threading.Tasks;
using ProductApp.DAL.Models.Product;

namespace ProductApp.DAL.Data.Repository.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetAllProductAsync();
        Task<ProductsPerPageEntity> GetProductsPerPageAsync(int page, int pageSize);
        Task<IEnumerable<ProductEntity>> GetByNameAsync(string name);
        Task CreateAsync(ProductEntity productEntity);
        Task<bool> DeleteAsync(int id);
        Task EditAsync(ProductEntity productEntity);

    }
}