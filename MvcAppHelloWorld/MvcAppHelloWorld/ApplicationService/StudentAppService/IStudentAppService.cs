using MvcAppHelloWorld.ApplicationService.Generic;
using MvcAppHelloWorld.ViewModels;
using MvcAppHelloWorld.QueryViewModel;

namespace MvcAppHelloWorld.ApplicationService.StudentAppService
{
    public interface IStudentAppService : IGenericAppService<StudentViewModel, StudentQueryViewModel>
    {
    }
}