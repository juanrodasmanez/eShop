using eShop.SharedKernel.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.SharedKernel.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        public virtual int Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public virtual bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TEntity> GetList()
        {
            throw new NotImplementedException();
        }

        public virtual IEnumerable<TEntity> GetListInPaginate()
        {
            throw new NotImplementedException();
        }

        public virtual TEntity ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public virtual bool Update(int id, TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
