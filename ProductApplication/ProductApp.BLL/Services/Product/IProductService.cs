using System.Collections.Generic;
using System.Threading.Tasks;
using ProductApp.BLL.Models;

namespace ProductApp.BLL.Services.Product
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDomain>> GetAllProductAsync();
        Task<PaginationDomain> GetProductsPerPageAsync(int page, int pageSize);
        Task<IEnumerable<ProductDomain>> GetByNameAsync(string name);
        Task CreateAsync(ProductDomain productDomain);
        Task<bool> DeleteAsync(int id);
        Task EditAsync(ProductDomain productDomain);
    }
}