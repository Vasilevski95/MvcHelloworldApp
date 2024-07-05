using MvcAppHelloWorld.ApplicationService.Generic;
using MvcAppHelloWorld.QueryViewModel;
using MvcAppHelloWorld.ViewModels;

namespace MvcAppHelloWorld.Controllers
{
    public class ProfessorController : GenericController<ProfessorViewModel, ProfessorQueryViewModel>
    {
        public ProfessorController(IGenericAppService<ProfessorViewModel, ProfessorQueryViewModel> appService)
            : base(appService) { }
    }
}
