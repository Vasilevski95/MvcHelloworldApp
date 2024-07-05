using System.Web.Mvc;
using AutoMapper;
using Unity;
using Unity.Mvc5;
using BusinessLayer.HighSchool;
using BusinessLayer.Student;
using _3_DataAccess.QueryRepository;
using _3_DataAccess.Generic;
using _3_DataAccess.HighSchool;
using _3_DataAccess.QueryModels;
using _3_DataAccess.Student;
using _4_BusinessObjectModel;
using BusinessLayer.Base;
using BusinessLayer.Generic;
using MvcAppHelloWorld.ApplicationService.Generic;
using MvcAppHelloWorld.QueryViewModel;
using MvcAppHelloWorld.ViewModels;
using MvcAppHelloWorld.ApplicationService.HighSchoolAppService;
using MvcAppHelloWorld.ApplicationService.StudentAppService;
using MvcAppHelloWorld.ApplicationService.ProfessorAppService;
using _3_DataAccess.Professor;
using BusinessLayer.Professor;

namespace MvcAppHelloWorld
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IGenericRepository<HighSchoolLearner>, HighSchoolLearnerRepository>();
            container.RegisterType<IGenericRepository<StudentLearner>, StudentLearnerRepository>();
            container.RegisterType<IGenericRepository<ProfessorModel>, ProfessorRepository>();

            container.RegisterType<IGenericService<HighSchoolLearner>, HighSchoolService>();
            container.RegisterType<IGenericService<StudentLearner>, StudentService>();
            container.RegisterType<IGenericService<ProfessorModel>, ProfessorService>();

            container.RegisterType<IGenericRepository<HighSchoolQueryModel>, HighSchoolQueryRepository>();
            container.RegisterType<IGenericRepository<StudentQueryModel>, StudentQueryRepository>();
            container.RegisterType<IGenericRepository<ProfessorQueryModel>, ProfessorQueryRepository>();

            container.RegisterType<IGenericService<HighSchoolQueryModel>, GenericService<HighSchoolQueryModel>>();
            container.RegisterType<IGenericService<StudentQueryModel>, GenericService<StudentQueryModel>>();
            container.RegisterType<IGenericService<ProfessorQueryModel>, GenericService<ProfessorQueryModel>>();

            container.RegisterType<IGenericAppService<HighSchoolViewModel, HighSchoolQueryViewModel>, HighSchoolAppService>();
            container.RegisterType<IGenericAppService<StudentViewModel, StudentQueryViewModel>, StudentAppService>();
            container.RegisterType<IGenericAppService<ProfessorViewModel, ProfessorQueryViewModel>, ProfessorAppService>();

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AutoMappingProfile>();
            });
            var mapper = config.CreateMapper();
            container.RegisterInstance(mapper);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}