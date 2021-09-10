using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using ProductApp.BLL.Models;
using ProductApp.BLL.Services.Product;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ResponseModel> GetAll(int page = 1)
        {
            var pageSize = 3;
            var products = await _productService.GetProductsPerPageAsync(page, pageSize);
            var test = products.PageModel;
            var mappedTest = _mapper.Map<PageViewModel>(test);
            var mappedResult = _mapper.Map<ResponseModel>(products);

            return mappedResult;
        }

        [HttpGet("by-name")]
        public async Task<IEnumerable<ProductViewModel>> GetByName(string name)
        {
            var product = name is null ? await _productService.GetAllProductAsync():await _productService.GetByNameAsync(name);
            var mappedProduct = _mapper.Map<IEnumerable<ProductViewModel>>(product);

            return mappedProduct;
        }

        [HttpPost("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task Edit([FromBody]ProductViewModel productModel)
        {
            var mappedModel = _mapper.Map<ProductDomain>(productModel);

            await _productService.EditAsync(mappedModel);
        }
        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task Create(ProductViewModel productModel)
        {
            var mappedModel = _mapper.Map<ProductDomain>(productModel);

            await _productService.CreateAsync(mappedModel);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Delete(int id)
        {
            return await _productService.DeleteAsync(id) == true ? Ok("Deleted") : BadRequest("No such user");
        }
    }
}
