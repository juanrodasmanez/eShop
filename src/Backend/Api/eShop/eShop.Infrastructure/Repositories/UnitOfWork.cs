using eShop.Core.Interfaces.Repositories;
using eShop.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppShopDbContext _context;

        private readonly IUserRepository _userRepository;

        public UnitOfWork(AppShopDbContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository => _userRepository ?? new MockUserRepository(_context);

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }
    }
}
