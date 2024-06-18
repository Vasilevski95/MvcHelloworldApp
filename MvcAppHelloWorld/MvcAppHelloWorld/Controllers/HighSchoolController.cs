using MvcAppHelloWorld.ApplicationService.Generic;
using MvcAppHelloWorld.ViewModels;

namespace MvcAppHelloWorld.Controllers
{
    public class HighSchoolController : GenericController<HighSchoolViewModel>
    {
        public HighSchoolController(IGenericAppService<HighSchoolViewModel> highSchoolAppService)
            : base(highSchoolAppService) { }
    }
}