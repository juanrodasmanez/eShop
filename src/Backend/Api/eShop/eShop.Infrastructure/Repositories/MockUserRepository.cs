using eShop.Core.Interfaces.Repositories;
using eShop.Core.Models;
using eShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Infrastructure.Repositories
{
    public class MockUserRepository : BaseRepository<UserModel>, IUserRepository
    {
        public MockUserRepository(AppShopDbContext context) : base(context)
        {
        }

        public override IEnumerable<UserModel> GetList()
        {
            IEnumerable<UserModel> list = new List<UserModel>
            {
                 new UserModel { Id = 1, Username = "juan", Password = "123456", Email = "jrodas@analytics.pe"}
            };
           
            return list;
        }
    }
}
