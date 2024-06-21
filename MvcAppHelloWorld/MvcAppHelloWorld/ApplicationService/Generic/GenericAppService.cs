// 1_Presentation/ApplicationService/Generic/GenericAppService.cs
using System;
using System.Collections.Generic;
using AutoMapper;
using BusinessLayer.Base;

namespace MvcAppHelloWorld.ApplicationService.Generic
{
    public class GenericAppService<TEntity, TViewModel, TQueryModel, TQueryViewModel> : IGenericAppService<TViewModel, TQueryViewModel>
        where TEntity : class
        where TViewModel : class
        where TQueryModel : class
        where TQueryViewModel : class
    {
        private readonly IGenericService<TEntity> _service;
        private readonly IGenericService<TQueryModel> _queryService;
        private readonly IMapper _mapper;

        public GenericAppService(IGenericService<TEntity> service, 
                                 IGenericService<TQueryModel> queryService,
                                 IMapper mapper)
        {
            _service = service;
            _queryService = queryService;
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

        public List<TQueryViewModel> GetAll()
        {
            var queryModels = _queryService.GetAll();
            return _mapper.Map<List<TQueryViewModel>>(queryModels);
        }

        public List<TQueryViewModel> Search(string searchTerm)
        {
            var queryModels = _queryService.Search(searchTerm);
            return _mapper.Map<List<TQueryViewModel>>(queryModels);
        }

        public virtual string GenerateDetailsContent(TViewModel viewModel)
        {
            return string.Empty;
        }
    }
}
