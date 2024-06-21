using _3_DataAccess.QueryModels;
using AutoMapper;
using MvcAppHelloWorld.ViewModels;
using _4_BusinessObjectModel;
using BusinessLayer.Base;
using MvcAppHelloWorld.ApplicationService.Generic;
using MvcAppHelloWorld.QueryViewModel;

namespace MvcAppHelloWorld.ApplicationService.StudentAppService
{
    public class StudentAppService : GenericAppService<StudentLearner, StudentViewModel, StudentQueryModel, StudentQueryViewModel>, IStudentAppService
    {
        public StudentAppService(IGenericService<StudentLearner> studentService, 
            IGenericService<StudentQueryModel> queryService,
            IMapper mapper)
            : base(studentService, queryService, mapper) { }

        public override string GenerateDetailsContent(StudentViewModel item)
        {
            return $"Name: {item.Name}\n" +
                   $"Surname: {item.Surname}\n" +
                   $"Date of Birth: {item.DateOfBirth:dd/MM/yyyy}\n" +
                   $"Email: {item.Email}\n" +
                   $"Phone: {item.Phone}\n" +
                   $"Address: {item.Address}\n" +
                   $"College Name: {item.CollegeName}\n" +
                   $"Generation: {item.Generation}\n";
        }
    }
}