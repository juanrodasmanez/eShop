using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Core.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }

        void SaveChange();
    }
}
