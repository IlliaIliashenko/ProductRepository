using AutoMapper;
using ProductApp.BLL.Models;
using ProductApp.DAL.Models.Authentication;

namespace ProductApp.BLL.Configuration.AutoMapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserEntity,UserDomain>().ReverseMap();
        }
    }
}