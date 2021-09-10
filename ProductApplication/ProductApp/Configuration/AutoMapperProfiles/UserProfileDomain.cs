using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ProductApp.BLL.Models;
using ProductApp.DAL.Models.Authentication;
using ProductApp.Models;

namespace ProductApp.Configuration.AutoMapperProfiles
{
    public class UserProfileDomain : Profile
    {
        public UserProfileDomain()
        {
            var hasher = new PasswordHasher<UserEntity>();
            CreateMap<RegisterUserModel, UserDomain>().ForMember(
                dest => dest.PasswordHash,
                opt => opt.MapFrom(src => hasher.HashPassword(null,src.Password)));
            CreateMap<LoginUserModel, LoginUserDomain>();
            CreateMap<TokenDomain, TokenResponseModel>();
        }
    }
}