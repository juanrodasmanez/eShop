
using eShop.Core.Models;
using eShop.SharedKernel.Repositories;
using System.Collections.Generic;

namespace eShop.Core.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<UserModel>
    {
        //public List<User> GetListEntities();
        
    }
}
