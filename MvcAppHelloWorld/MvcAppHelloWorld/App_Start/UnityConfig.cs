using System.Web.Mvc;
using _3_DataAccess;
using _3_DataAccess.HighSchool;
using _3_DataAccess.Student;
using BusinessLayer.HighSchool;
using BusinessLayer.Student;
using Unity;
using Unity.Mvc5;

namespace MvcAppHelloWorld
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();
            
            
            container.RegisterType<IHighSchoolLearnerRepository, HighSchoolLearnerRepository>();
            container.RegisterType<IStudentLearnerRepository, StudentLearnerRepository>();
            
            container.RegisterType<IHighSchoolService, HighSchoolService>();
            container.RegisterType<IStudentService, StudentService>();
            container.RegisterType<IRoleRepository, RoleRepository>();
            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}