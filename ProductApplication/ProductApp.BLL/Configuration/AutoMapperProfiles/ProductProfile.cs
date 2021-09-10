using ProductApp.BLL.Models;
using ProductApp.DAL.Models.Product;

namespace ProductApp.BLL.Configuration.AutoMapperProfiles
{
    public class ProductProfile : UserProfile
    {
        public ProductProfile()
        {
            CreateMap<ProductEntity, ProductDomain>().ReverseMap();
        }
    }
}