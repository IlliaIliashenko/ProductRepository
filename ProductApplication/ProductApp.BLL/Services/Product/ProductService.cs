using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ProductApp.BLL.Models;
using ProductApp.DAL.Data.Repository.Interfaces;
using ProductApp.DAL.Models.Product;

namespace ProductApp.BLL.Services.Product
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDomain>> GetAllProductAsync()
        {
            var products = await _productRepository.GetAllProductAsync();
            var mappedProducts = _mapper.Map<IEnumerable<ProductDomain>>(products);

            return mappedProducts;
        }

        public async Task<PaginationDomain> GetProductsPerPageAsync(int page, int pageSize)
        {
            var productsPerPage = await _productRepository.GetProductsPerPageAsync(page,pageSize);
            var result = productsPerPage.ProductEntities;
            var count = productsPerPage.Count;

            var pageModel = new PageDomain(count, page, pageSize);

            var mappedProducts = _mapper.Map<IEnumerable<ProductDomain>>(result);

            var paginationModel = new PaginationDomain()
            {
                PageModel = pageModel,
                Products = mappedProducts
            };

            return paginationModel;
        }

        public async Task<IEnumerable<ProductDomain>> GetByNameAsync(string name)
        {
            var product = await _productRepository.GetByNameAsync(name);
            var mappedProduct = _mapper.Map<IEnumerable<ProductDomain>>(product);

            return mappedProduct;
        }

        public async Task CreateAsync(ProductDomain productDomain)
        {
            var mappedProduct = _mapper.Map<ProductEntity>(productDomain);

            await _productRepository.CreateAsync(mappedProduct);
        }

        public async Task<bool> DeleteAsync(int id)
        {
           var result = await _productRepository.DeleteAsync(id);

           return result;
        }

        public async Task EditAsync(ProductDomain productDomain)
        {
            var mappedProduct = _mapper.Map<ProductEntity>(productDomain);

            await _productRepository.EditAsync(mappedProduct);
        }
    }
}