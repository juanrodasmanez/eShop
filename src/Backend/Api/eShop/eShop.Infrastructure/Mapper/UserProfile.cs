using AutoMapper;
using eShop.Core.Models;
using eShop.Core.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
