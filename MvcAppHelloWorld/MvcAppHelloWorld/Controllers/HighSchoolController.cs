using MvcAppHelloWorld.ApplicationService.Generic;
using MvcAppHelloWorld.QueryViewModel;
using MvcAppHelloWorld.ViewModels;

namespace MvcAppHelloWorld.Controllers
{
    public class HighSchoolController : GenericController<HighSchoolViewModel, HighSchoolQueryViewModel>
    {
        public HighSchoolController(IGenericAppService<HighSchoolViewModel, HighSchoolQueryViewModel> appService)
            : base(appService) { }
    }
}