using MvcAppHelloWorld.ViewModels;
using System;
using System.Collections.Generic;

namespace MvcAppHelloWorld.ApplicationService.HighSchoolAppService
{
    public interface IHighSchoolAppService
    {
        void AddHighSchoolLearner(HighSchoolViewModel highSchoolLearner);
        void UpdateHighSchoolLearner(HighSchoolViewModel highSchoolLearner);
        void DeleteHighSchoolLearner(Guid id);
        HighSchoolViewModel GetHighSchoolLearnerById(Guid id);
        List<HighSchoolViewModel> GetAllHighSchoolLearners();
        List<HighSchoolViewModel> SearchHighSchoolLearners(string searchTerm);
    }
}