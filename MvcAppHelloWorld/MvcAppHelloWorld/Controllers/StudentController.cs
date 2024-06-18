using MvcAppHelloWorld.ApplicationService.Generic;
using MvcAppHelloWorld.ViewModels;

namespace MvcAppHelloWorld.Controllers
{
    public class StudentController : GenericController<StudentViewModel>
    {
        public StudentController(IGenericAppService<StudentViewModel> studentAppService)
            : base(studentAppService) { }
    }
}