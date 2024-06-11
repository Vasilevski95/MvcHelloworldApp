using System;
using System.Collections.Generic;
using _4_BusinessObjectModel;

namespace _3_DataAccess.HighSchool
{
    public interface IHighSchoolLearnerRepository
    {
        void Add(HighSchoolLearner highSchoolLearner);
        void Update(HighSchoolLearner highSchoolLearner);
        void Delete(Guid id);
        HighSchoolLearner GetById(Guid id);
        List<HighSchoolLearner> GetAll();
        List<HighSchoolLearner> SearchHighSchoolLearners(string searchTerm);
    }
}