﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.SharedKernel.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        int Create(TEntity entity);

        TEntity ReadById(int id);

        bool Update(int id, TEntity entity);

        bool Delete(int id);

        List<TEntity> GetList();

        List<TEntity> GetListInPaginate();
    }
}