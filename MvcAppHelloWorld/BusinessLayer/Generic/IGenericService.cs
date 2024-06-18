using System;
using System.Collections.Generic;

namespace BusinessLayer.Base
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(Guid id);
        TEntity GetById(Guid id);
        List<TEntity> GetAll();
        List<TEntity> Search(string searchTerm);
    }
}