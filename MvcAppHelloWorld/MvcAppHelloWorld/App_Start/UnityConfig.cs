using System.Web.Mvc;
using AutoMapper;
using Unity;
using Unity.Mvc5;
using MvcAppHelloWorld.ApplicationService.HighSchoolAppService;
using MvcAppHelloWorld.ApplicationService.StudentAppService;
using BusinessLayer.HighSchool;
using BusinessLayer.Student;
using _3_DataAccess;
using _3_DataAccess.HighSchool;
using _3_DataAccess.Student;

namespace MvcAppHelloWorld
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            container.RegisterType<IHighSchoolLearnerRepository, HighSchoolLearnerRepository>();
            container.RegisterType<IStudentLearnerRepository, StudentLearnerRepository>();
            container.RegisterType<IRoleRepository, RoleRepository>();
            
            container.RegisterType<IHighSchoolService, HighSchoolService>();
            container.RegisterType<IStudentService, StudentService>();
            container.RegisterType<IHighSchoolAppService, HighSchoolAppService>();
            container.RegisterType<IStudentAppService, StudentAppService>();

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