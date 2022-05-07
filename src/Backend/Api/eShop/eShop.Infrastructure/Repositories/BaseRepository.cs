using eShop.Infrastructure.Data;
using eShop.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.Infrastructure.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly AppShopDbContext _context;
        protected readonly DbSet<TEntity> _entities;

        public BaseRepository(AppShopDbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public virtual TEntity Create(TEntity entity)
        {
            _entities.Add(entity);
            return entity;
        }

        public virtual bool Delete(int id)
        {
            TEntity entity = ReadById(id);
            _entities.Remove(entity);
            return true;
        }

        public virtual IEnumerable<TEntity> GetList()
        {
            return _entities.AsEnumerable();
        }

        public virtual IEnumerable<TEntity> GetListInPaginate()
        {
            return _entities.AsEnumerable();
        }

        public virtual TEntity ReadById(int id)
        {
            return _entities.Find(id);
        }

        public virtual bool Update(int id, TEntity entity)
        {
            TEntity entityModel = ReadById(id);
            _entities.Update(entityModel);
            return true;
        }
    }
}
