using AutoMapper;
using eShop.Core.Models;
using eShop.Core.Response;
using eShop.Infrastructure.Entities;

namespace eShop.Infrastructure.Mapper
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserModel, UserDtoResponse>();
        }
    }
}
