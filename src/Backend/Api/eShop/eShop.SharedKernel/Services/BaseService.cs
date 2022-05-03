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
        public int Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetList()
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetListInPaginate()
        {
            throw new NotImplementedException();
        }

        public TEntity ReadById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(int id, TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
