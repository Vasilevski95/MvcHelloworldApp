using System;
using _4_BusinessObjectModel;
using _3_DataAccess.HighSchool;
using System.Collections.Generic;

namespace BusinessLayer.HighSchool
{
    public class HighSchoolService : IHighSchoolService
    {
        private readonly IHighSchoolLearnerRepository _repository;

        public HighSchoolService(IHighSchoolLearnerRepository repository)
        {
            _repository = repository;
        }

        public void AddHighSchoolLearner(HighSchoolLearner highSchoolLearner)
        {
            _repository.Add(highSchoolLearner);
        }

        public void UpdateHighSchoolLearner(HighSchoolLearner highSchoolLearner)
        {
            _repository.Update(highSchoolLearner);
        }

        public void DeleteHighSchoolLearner(Guid id)
        {
            _repository.Delete(id);
        }

        public HighSchoolLearner GetHighSchoolLearnerById(Guid id)
        {
            return _repository.GetById(id);
        }

        public List<HighSchoolLearner> GetAllHighSchoolLearners()
        {
            return _repository.GetAll();
        }
        
        public List<HighSchoolLearner> SearchHighSchoolLearners(string searchTerm)
        {
            return _repository.SearchHighSchoolLearners(searchTerm);
        }
    }
}