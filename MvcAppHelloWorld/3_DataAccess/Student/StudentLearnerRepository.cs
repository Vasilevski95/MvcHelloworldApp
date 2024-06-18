using System;
using System.Collections.Generic;
using System.Linq;
using _3_DataAccess.Generic;
using _4_BusinessObjectModel;

namespace _3_DataAccess.Student
{
    public class StudentLearnerRepository : UserRepositoryBase<StudentLearner>, IStudentLearnerRepository
    {
        public StudentLearnerRepository(TuxContext context) : base(context)
        {
        }

        protected override string GetRoleName(User user)
        {
            return "StudentLearner";
        }

        protected override List<StudentLearner> AdditionalSearchCondition(string searchTerm, bool isDate, DateTime parsedDate)
        {
            return DbSet.Where(s =>
                s.CollegeName.Contains(searchTerm) ||
                s.Generation.ToString().Contains(searchTerm)
            ).ToList();
        }
    }
}