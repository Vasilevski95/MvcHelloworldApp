using MvcAppHelloWorld.ApplicationService.Generic;
using MvcAppHelloWorld.QueryViewModel;
using MvcAppHelloWorld.ViewModels;

namespace MvcAppHelloWorld.Controllers
{
    public class StudentController : GenericController<StudentViewModel, StudentQueryViewModel>
    {
        public StudentController(IGenericAppService<StudentViewModel, StudentQueryViewModel> appService)
            : base(appService) { }
    }
}