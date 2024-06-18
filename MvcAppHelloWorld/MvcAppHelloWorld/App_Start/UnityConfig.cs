using System.Web.Mvc;
using AutoMapper;
using Unity;
using Unity.Mvc5;
using MvcAppHelloWorld.ApplicationService.HighSchoolAppService;
using MvcAppHelloWorld.ApplicationService.StudentAppService;
using BusinessLayer.HighSchool;
using BusinessLayer.Student;
using _3_DataAccess.Generic;
using _3_DataAccess.HighSchool;
using _3_DataAccess.Student;
using BusinessLayer.Base;
using _4_BusinessObjectModel;
using MvcAppHelloWorld.ApplicationService.Generic;
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

            container.RegisterType<IGenericAppService<HighSchoolViewModel>, HighSchoolAppService>();
            container.RegisterType<IGenericAppService<StudentViewModel>, StudentAppService>();

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