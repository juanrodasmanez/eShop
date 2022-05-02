using eShop.SharedKernel.Repositories;
using eShop.SharedKernel.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.SharedKernel.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public int CreateEntity(TEntity entity)
        {
            return _repository.CreateEntity(entity);
        }

        public bool DeleteEntity(TEntity entity)
        {
            return _repository.DeleteEntity(entity);
        }

        public virtual List<TEntity> GetListEntities()
        {
            return _repository.GetListEntities();
        }

        public List<TEntity> GetListEntitiesInPaginate()
        {
            return _repository.GetListEntitiesInPaginate();
        }

        public TEntity ReadEntityById(int id)
        {
            return _repository.ReadEntityById(id);
        }

        public bool UpdateEntity(TEntity entity)
        {
            return _repository.UpdateEntity(entity);
        }
    }
}
