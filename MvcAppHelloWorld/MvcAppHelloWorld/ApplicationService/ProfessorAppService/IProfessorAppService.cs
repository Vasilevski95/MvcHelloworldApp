using MvcAppHelloWorld.ApplicationService.Generic;
using MvcAppHelloWorld.ViewModels;
using MvcAppHelloWorld.QueryViewModel;

namespace MvcAppHelloWorld.ApplicationService.ProfessorAppService
{
    public interface IProfessorAppService : IGenericAppService<ProfessorViewModel, ProfessorQueryViewModel>
    {
    }
}