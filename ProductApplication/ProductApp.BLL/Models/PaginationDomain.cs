using System.Collections.Generic;

namespace ProductApp.BLL.Models
{
    public class PaginationDomain
    {
        public IEnumerable<ProductDomain> Products { get; set; }
        public PageDomain PageModel { get; set; }
    }
}