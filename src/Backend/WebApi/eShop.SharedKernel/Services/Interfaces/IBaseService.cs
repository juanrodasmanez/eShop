using eShop.SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.SharedKernel.Services.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        List<TEntity> GetListEntities();

        List<TEntity> GetListEntitiesInPaginate();

        int CreateEntity(TEntity entity);

        TEntity ReadEntityById(int id);

        bool UpdateEntity(TEntity entity);

        bool DeleteEntity(TEntity entity);
    }
}
