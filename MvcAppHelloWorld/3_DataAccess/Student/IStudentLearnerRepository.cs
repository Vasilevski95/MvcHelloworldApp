using System;
using _4_BusinessObjectModel;
using System.Collections.Generic;

namespace _3_DataAccess.Student
{
    public interface IStudentLearnerRepository
    {
        void Add(StudentLearner studentLearner);
        void Update(StudentLearner studentLearner);
        void Delete(Guid id);
        StudentLearner GetById(Guid id);
        IEnumerable<StudentLearner> GetAll();
        IEnumerable<StudentLearner> SearchStudentLearners(string searchTerm);
    }
}