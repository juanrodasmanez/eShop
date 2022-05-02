using eShop.Core.Interfaces.Repositories;
using eShop.Core.Models;
using eShop.SharedKernel.Repositories;
using System.Collections.Generic;

namespace eShop.Infrastructure.Repositories
{
    public class MockupUserRepository : BaseRepository<User>, IUserRepository
    {
        public override List<User> GetListEntities()
        {
            List<User> items = new List<User>
            {
                new User { Id = 1, Username = "juan", Password = "123456"}
            };
            return items;
        }
    }
}
