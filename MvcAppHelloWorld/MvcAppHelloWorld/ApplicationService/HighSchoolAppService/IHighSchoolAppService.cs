using MvcAppHelloWorld.ApplicationService.Generic;
using MvcAppHelloWorld.ViewModels;
using MvcAppHelloWorld.QueryViewModel;

namespace MvcAppHelloWorld.ApplicationService.HighSchoolAppService
{
    public interface IHighSchoolAppService : IGenericAppService<HighSchoolViewModel, HighSchoolQueryViewModel>
    {
    }
}