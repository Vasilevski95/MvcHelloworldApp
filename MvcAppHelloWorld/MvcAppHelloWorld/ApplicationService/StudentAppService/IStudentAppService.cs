using MvcAppHelloWorld.ViewModels;
using System;
using System.Collections.Generic;

namespace MvcAppHelloWorld.ApplicationService.StudentAppService
{
    public interface IStudentAppService
    {
        void AddStudentLearner(StudentViewModel studentLearner);
        void UpdateStudentLearner(StudentViewModel studentLearner);
        void DeleteStudentLearner(Guid id);
        StudentViewModel GetStudentLearnerById(Guid id);
        IEnumerable<StudentViewModel> GetAllStudentLearners();
        IEnumerable<StudentViewModel> SearchStudentLearners(string searchTerm);
    }
}