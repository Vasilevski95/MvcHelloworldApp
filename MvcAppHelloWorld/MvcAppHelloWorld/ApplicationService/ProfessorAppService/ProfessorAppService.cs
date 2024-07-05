using _3_DataAccess.QueryModels;
using AutoMapper;
using MvcAppHelloWorld.ViewModels;
using _4_BusinessObjectModel;
using BusinessLayer.Base;
using MvcAppHelloWorld.ApplicationService.Generic;
using MvcAppHelloWorld.QueryViewModel;

namespace MvcAppHelloWorld.ApplicationService.ProfessorAppService
{
    public class ProfessorAppService : GenericAppService<ProfessorModel, ProfessorViewModel, ProfessorQueryModel, ProfessorQueryViewModel>, IProfessorAppService
    {
        public ProfessorAppService(IGenericService<ProfessorModel> professorService,
            IGenericService<ProfessorQueryModel> queryService,
            IMapper mapper)
            : base(professorService, queryService, mapper)
        {
        }

        public override string GenerateDetailsContent(ProfessorViewModel item)
        {
            return $"Name: {item.Name}\n" +
                   $"Surname: {item.Surname}\n" +
                   $"Date of Birth: {item.DateOfBirth:dd/MM/yyyy}\n" +
                   $"Email: {item.Email}\n" +
                   $"Phone: {item.Phone}\n" +
                   $"Address: {item.Address}\n" +
                   $"Class subject: {item.ClassSubject}\n" +
                   $"Cabinet: {item.Cabinet}";
        }
    }
}