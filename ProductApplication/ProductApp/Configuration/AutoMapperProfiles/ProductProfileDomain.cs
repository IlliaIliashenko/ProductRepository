using AutoMapper;
using ProductApp.BLL.Models;
using ProductApp.Models;

namespace ProductApp.Configuration.AutoMapperProfiles
{
    public class ProductProfileDomain : Profile
    {
        public ProductProfileDomain()
        {
            CreateMap<ProductDomain,ProductViewModel>().ReverseMap();
            CreateMap<PageDomain,PageViewModel>();
            CreateMap<PaginationDomain,ResponseModel>();
        }
    }
}