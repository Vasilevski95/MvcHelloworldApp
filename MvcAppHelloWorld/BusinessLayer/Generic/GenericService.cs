using System;
using System.Collections.Generic;
using _3_DataAccess.Generic;
using BusinessLayer.Base;

namespace BusinessLayer.Generic
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity : class
    {
        private readonly IGenericRepository<TEntity> _repository;

        public GenericService(IGenericRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public virtual void Delete(Guid id)
        {
            _repository.Delete(id);
        }

        public virtual TEntity GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        public virtual List<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public virtual List<TEntity> Search(string searchTerm)
        {
            return _repository.Search(searchTerm);
        }
    }
}