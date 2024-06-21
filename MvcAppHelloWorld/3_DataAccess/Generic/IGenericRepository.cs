using System;
using System.Collections.Generic;

namespace _3_DataAccess.Generic
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid id);
        TEntity GetById(Guid id);
        List<TEntity> GetAll();
        List<TEntity> Search(string searchTerm);
    }

}