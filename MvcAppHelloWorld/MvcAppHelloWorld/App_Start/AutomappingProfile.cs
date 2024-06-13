using AutoMapper;
using MvcAppHelloWorld.ViewModels;
using _4_BusinessObjectModel;

namespace MvcAppHelloWorld
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<HighSchoolLearner, HighSchoolViewModel>().ReverseMap();
            CreateMap<StudentLearner, StudentViewModel>().ReverseMap();
        }
    }
}