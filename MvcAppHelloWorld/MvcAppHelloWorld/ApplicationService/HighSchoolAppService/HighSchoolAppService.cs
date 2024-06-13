using AutoMapper;
using MvcAppHelloWorld.ViewModels;
using _4_BusinessObjectModel;
using BusinessLayer.HighSchool;
using System;
using System.Collections.Generic;

namespace MvcAppHelloWorld.ApplicationService.HighSchoolAppService
{
    public class HighSchoolAppService : IHighSchoolAppService
    {
        private readonly IHighSchoolService _highSchoolService;
        private readonly IMapper _mapper;

        public HighSchoolAppService(IHighSchoolService highSchoolService, IMapper mapper)
        {
            _highSchoolService = highSchoolService;
            _mapper = mapper;
        }

        public void AddHighSchoolLearner(HighSchoolViewModel highSchoolLearner)
        {
            var learner = _mapper.Map<HighSchoolLearner>(highSchoolLearner);
            _highSchoolService.AddHighSchoolLearner(learner);
        }

        public void UpdateHighSchoolLearner(HighSchoolViewModel highSchoolLearner)
        {
            var learner = _mapper.Map<HighSchoolLearner>(highSchoolLearner);
            _highSchoolService.UpdateHighSchoolLearner(learner);
        }

        public void DeleteHighSchoolLearner(Guid id)
        {
            _highSchoolService.DeleteHighSchoolLearner(id);
        }

        public HighSchoolViewModel GetHighSchoolLearnerById(Guid id)
        {
            var learner = _highSchoolService.GetHighSchoolLearnerById(id);
            return _mapper.Map<HighSchoolViewModel>(learner);
        }

        public List<HighSchoolViewModel> GetAllHighSchoolLearners()
        {
            var learners = _highSchoolService.GetAllHighSchoolLearners();
            return _mapper.Map<List<HighSchoolViewModel>>(learners);
        }
        
        public List<HighSchoolViewModel> SearchHighSchoolLearners(string searchTerm)
        {
            var learners = _highSchoolService.SearchHighSchoolLearners(searchTerm);
            return _mapper.Map<List<HighSchoolViewModel>>(learners);
        }
    }
}