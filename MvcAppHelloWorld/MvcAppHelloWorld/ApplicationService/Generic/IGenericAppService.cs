using System;
using System.Collections.Generic;

namespace MvcAppHelloWorld.ApplicationService.Generic
{
    public interface IGenericAppService<TViewModel> where TViewModel : class
    {
        void Add(TViewModel viewModel);
        void Update(TViewModel viewModel);
        void Delete(Guid id);
        TViewModel GetById(Guid id);
        List<TViewModel> GetAll();
        List<TViewModel> Search(string searchTerm);
        string GenerateDetailsContent(TViewModel viewModel); 
    }
}