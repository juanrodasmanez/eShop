using AutoMapper;
using eShop.Core.Interfaces.Repositories;
using eShop.Core.Models;
using eShop.Infrastructure.Entities;
using eShop.SharedKernel.Repositories;
using System.Collections.Generic;

namespace eShop.Infrastructure.Repositories
{
    public class MockupUserRepository : BaseRepository<UserModel>, IUserRepository
    {
        private readonly IMapper _mapper;
        public MockupUserRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public override List<UserModel> GetListEntities()
        {
            List<UserModel> items = new List<UserModel>
            {
                new UserModel { Id = 1, Username = "juan", Password = "123456"}
            };
            return _mapper.Map<List<UserModel>>(items);
        }
    }
}
