// 1_Presentation/App_Start/UnityConfig.cs
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
using MvcAppHelloWorld.ApplicationService.HighSchoolAppService;
using MvcAppHelloWorld.ApplicationService.StudentAppService;
using MvcAppHelloWorld.QueryViewModel;
using MvcAppHelloWorld.ViewModels;

namespace MvcAppHelloWorld
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IGenericRepository<HighSchoolLearner>, HighSchoolLearnerRepository>();
            container.RegisterType<IGenericRepository<StudentLearner>, StudentLearnerRepository>();

            container.RegisterType<IGenericService<HighSchoolLearner>, HighSchoolService>();
            container.RegisterType<IGenericService<StudentLearner>, StudentService>();

            container.RegisterType<IHighSchoolAppService, HighSchoolAppService>();
            container.RegisterType<IStudentAppService, StudentAppService>();

            container.RegisterType<IGenericRepository<HighSchoolQueryModel>, HighSchoolQueryRepository>();
            container.RegisterType<IGenericRepository<StudentQueryModel>, StudentQueryRepository>();

            container.RegisterType<IGenericService<HighSchoolQueryModel>, GenericService<HighSchoolQueryModel>>();
            container.RegisterType<IGenericService<StudentQueryModel>, GenericService<StudentQueryModel>>();

            container.RegisterType<IGenericAppService<HighSchoolViewModel, HighSchoolQueryViewModel>, GenericAppService<HighSchoolLearner, HighSchoolViewModel, HighSchoolQueryModel, HighSchoolQueryViewModel>>();
            container.RegisterType<IGenericAppService<StudentViewModel, StudentQueryViewModel>, GenericAppService<StudentLearner, StudentViewModel, StudentQueryModel, StudentQueryViewModel>>();

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
