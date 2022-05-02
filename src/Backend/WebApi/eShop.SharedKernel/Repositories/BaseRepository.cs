using eShop.SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.SharedKernel.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        public int CreateEntity(TEntity entity)
        {
            return 1;
        }

        public bool DeleteEntity(TEntity entity)
        {
            return true;
        }

        public virtual List<TEntity> GetListEntities()
        {
            List<TEntity> items = new List<TEntity>();
            return items;
        }

        public List<TEntity> GetListEntitiesInPaginate()
        {
            List<TEntity> items = new List<TEntity>();
            return items;
        }

        public TEntity ReadEntityById(int id)
        {
           TEntity entity = null;
           return entity;
        }

        public bool UpdateEntity(TEntity entity)
        {
            return true;
        }
    }
}
