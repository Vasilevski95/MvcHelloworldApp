using System;
using _4_BusinessObjectModel;
using System.Collections.Generic;

namespace BusinessLayer.HighSchool
{
    public interface IHighSchoolService
    {
        void AddHighSchoolLearner(HighSchoolLearner highSchoolLearner);
        void UpdateHighSchoolLearner(HighSchoolLearner highSchoolLearner);
        void DeleteHighSchoolLearner(Guid id);
        HighSchoolLearner GetHighSchoolLearnerById(Guid id);
        List<HighSchoolLearner> GetAllHighSchoolLearners();
        List<HighSchoolLearner> SearchHighSchoolLearners(string searchTerm);
    }
}