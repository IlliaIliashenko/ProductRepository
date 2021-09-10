using System.Collections.Generic;

namespace ProductApp.DAL.Models.Product
{
    public class ProductsPerPageEntity
    {
        public IEnumerable<ProductEntity> ProductEntities { get; set; }
        public int Count { get; set; }
    }
}