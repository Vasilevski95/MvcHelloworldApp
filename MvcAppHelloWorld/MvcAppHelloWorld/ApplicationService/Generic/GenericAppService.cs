using System;
using System.Collections.Generic;
using AutoMapper;
using BusinessLayer.Base;

namespace MvcAppHelloWorld.ApplicationService.Generic
{
    public class GenericAppService<TEntity, TViewModel> : IGenericAppService<TViewModel>
        where TEntity : class
        where TViewModel : class
    {
        private readonly IGenericService<TEntity> _service;
        private readonly IMapper _mapper;

        public GenericAppService(IGenericService<TEntity> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public void Add(TViewModel viewModel)
        {
            var entity = _mapper.Map<TEntity>(viewModel);
            _service.Add(entity);
        }

        public void Update(TViewModel viewModel)
        {
            var entity = _mapper.Map<TEntity>(viewModel);
            _service.Update(entity);
        }

        public void Delete(Guid id)
        {
            _service.Delete(id);
        }

        public TViewModel GetById(Guid id)
        {
            var entity = _service.GetById(id);
            return _mapper.Map<TViewModel>(entity);
        }

        public List<TViewModel> GetAll()
        {
            var entities = _service.GetAll();
            return _mapper.Map<List<TViewModel>>(entities);
        }

        public List<TViewModel> Search(string searchTerm)
        {
            var entities = _service.Search(searchTerm);
            return _mapper.Map<List<TViewModel>>(entities);
        }

        public virtual string GenerateDetailsContent(TViewModel viewModel)
        {
            return string.Empty;
        }
    }
}