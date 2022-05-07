using eShop.Core.Models;
using eShop.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Core.Interfaces.Repositories
{
    public interface IUserRepository : IBaseRepository<UserModel>
    {
    }
}
