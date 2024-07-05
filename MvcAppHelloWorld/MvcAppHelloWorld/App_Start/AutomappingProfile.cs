using _3_DataAccess.QueryModels;
using AutoMapper;
using MvcAppHelloWorld.ViewModels;
using _4_BusinessObjectModel;
using MvcAppHelloWorld.QueryViewModel;

namespace MvcAppHelloWorld
{
    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<HighSchoolLearner, HighSchoolViewModel>().ReverseMap();
            CreateMap<StudentLearner, StudentViewModel>().ReverseMap();
            CreateMap<ProfessorModel, ProfessorViewModel>().ReverseMap();
            CreateMap<HighSchoolQueryModel, HighSchoolQueryViewModel>().ReverseMap();
            CreateMap<StudentQueryModel, StudentQueryViewModel>().ReverseMap();
            CreateMap<ProfessorQueryModel, ProfessorQueryViewModel>().ReverseMap();
            CreateMap<RoleQueryModel, RoleQueryViewModel>().ReverseMap();
        }
    }
}