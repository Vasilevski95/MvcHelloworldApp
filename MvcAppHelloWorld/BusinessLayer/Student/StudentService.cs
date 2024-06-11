using System;
using _4_BusinessObjectModel;
using _3_DataAccess.Student;
using System.Collections.Generic;

namespace BusinessLayer.Student
{
    public class StudentService : IStudentService
    {
        private readonly IStudentLearnerRepository _repository;

        public StudentService(IStudentLearnerRepository repository)
        {
            _repository = repository;
        }

        public void AddStudentLearner(StudentLearner studentLearner)
        {
            _repository.Add(studentLearner);
        }

        public void UpdateStudentLearner(StudentLearner studentLearner)
        {
            _repository.Update(studentLearner);
        }

        public void DeleteStudentLearner(Guid id)
        {
            _repository.Delete(id);
        }

        public StudentLearner GetStudentLearnerById(Guid id)
        {
            return _repository.GetById(id);
        }

        public IEnumerable<StudentLearner> GetAllStudentLearners()
        {
            return _repository.GetAll();
        }
        
        public IEnumerable<StudentLearner> SearchStudentLearners(string searchTerm)
        {
            return _repository.SearchStudentLearners(searchTerm);
        }
    }
}