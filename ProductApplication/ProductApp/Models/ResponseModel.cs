using System.Collections.Generic;

namespace ProductApp.Models
{
    public class ResponseModel
    {
        public IEnumerable<ProductViewModel> Products { get; set; }
        public PageViewModel PageModel { get; set; }
    }
}