using AutoMapper;
using MvcAppHelloWorld.ViewModels;
using _4_BusinessObjectModel;
using BusinessLayer.Student;
using System;
using System.Collections.Generic;

namespace MvcAppHelloWorld.ApplicationService.StudentAppService
{
    public class StudentAppService : IStudentAppService
    {
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        public StudentAppService(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }

        public void AddStudentLearner(StudentViewModel studentLearner)
        {
            var learner = _mapper.Map<StudentLearner>(studentLearner);
            _studentService.AddStudentLearner(learner);
        }

        public void UpdateStudentLearner(StudentViewModel studentLearner)
        {
            var learner = _mapper.Map<StudentLearner>(studentLearner);
            _studentService.UpdateStudentLearner(learner);
        }

        public void DeleteStudentLearner(Guid id)
        {
            _studentService.DeleteStudentLearner(id);
        }

        public StudentViewModel GetStudentLearnerById(Guid id)
        {
            var learner = _studentService.GetStudentLearnerById(id);
            return _mapper.Map<StudentViewModel>(learner);
        }

        public IEnumerable<StudentViewModel> GetAllStudentLearners()
        {
            var learners = _studentService.GetAllStudentLearners();
            return _mapper.Map<IEnumerable<StudentViewModel>>(learners);
        }
        
        public IEnumerable<StudentViewModel> SearchStudentLearners(string searchTerm)
        {
            var learners = _studentService.SearchStudentLearners(searchTerm);
            return _mapper.Map<IEnumerable<StudentViewModel>>(learners);
        }
    }
}