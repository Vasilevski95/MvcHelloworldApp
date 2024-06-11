using System;
using _4_BusinessObjectModel;
using System.Collections.Generic;

namespace BusinessLayer.Student
{
    public interface IStudentService
    {
        void AddStudentLearner(StudentLearner studentLearner);
        void UpdateStudentLearner(StudentLearner studentLearner);
        void DeleteStudentLearner(Guid id);
        StudentLearner GetStudentLearnerById(Guid id);
        IEnumerable<StudentLearner> GetAllStudentLearners();
        IEnumerable<StudentLearner> SearchStudentLearners(string searchTerm);
    }
}