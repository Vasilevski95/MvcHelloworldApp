using _3_DataAccess.Generic;
using _4_BusinessObjectModel;
using BusinessLayer.Generic;

namespace BusinessLayer.Student
{
    public class StudentService : GenericService<StudentLearner>, IStudentService
    {
        public StudentService(IGenericRepository<StudentLearner> repository) : base(repository) { }
    }
}