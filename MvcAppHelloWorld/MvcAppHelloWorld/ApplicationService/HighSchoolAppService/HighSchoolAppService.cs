using System;
using _3_DataAccess.QueryModels;
using AutoMapper;
using MvcAppHelloWorld.ViewModels;
using _4_BusinessObjectModel;
using BusinessLayer.Base;
using MvcAppHelloWorld.ApplicationService.Generic;
using MvcAppHelloWorld.QueryViewModel;

namespace MvcAppHelloWorld.ApplicationService.HighSchoolAppService
{
    public class HighSchoolAppService : GenericAppService<HighSchoolLearner, HighSchoolViewModel, HighSchoolQueryModel, HighSchoolQueryViewModel>, IHighSchoolAppService
    {
        public HighSchoolAppService(IGenericService<HighSchoolLearner> highSchoolService, 
            IGenericService<HighSchoolQueryModel> queryService,
            IMapper mapper)
            : base(highSchoolService, queryService, mapper)
        {
        }

        public override string GenerateDetailsContent(HighSchoolViewModel item)
        {
            return $"Name: {item.Name}\n" +
                   $"Surname: {item.Surname}\n" +
                   $"Date of Birth: {item.DateOfBirth:dd/MM/yyyy}\n" +
                   $"Email: {item.Email}\n" +
                   $"Phone: {item.Phone}\n" +
                   $"Address: {item.Address}\n" +
                   $"School Name: {item.SchoolName}\n" +
                   $"Date of Entry: {item.DateOfEntry:dd/MM/yyyy}\n";
        }
    }
}