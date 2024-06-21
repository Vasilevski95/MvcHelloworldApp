using System;
using System.Collections.Generic;

namespace MvcAppHelloWorld.ApplicationService.Generic
{
    public interface IGenericAppService<TViewModel, TQueryViewModel> 
        where TViewModel : class
        where TQueryViewModel : class
    {
        void Add(TViewModel viewModel);
        void Update(TViewModel viewModel);
        void Delete(Guid id);
        TViewModel GetById(Guid id);
        List<TQueryViewModel> GetAll();
        List<TQueryViewModel> Search(string searchTerm);
        string GenerateDetailsContent(TViewModel viewModel); 
    }
}