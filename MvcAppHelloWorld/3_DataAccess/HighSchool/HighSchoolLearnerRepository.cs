using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using _3_DataAccess.Generic;
using _4_BusinessObjectModel;

namespace _3_DataAccess.HighSchool
{
    public class HighSchoolLearnerRepository : UserRepositoryBase<HighSchoolLearner>, IHighSchoolLearnerRepository
    {
        public HighSchoolLearnerRepository(TuxContext context) : base(context)
        {
        }

        protected override string GetRoleName(User user)
        {
            return "HighSchoolLearner";
        }

        protected override List<HighSchoolLearner> AdditionalSearchCondition(string query, bool isDate, DateTime parsedDate)
        {
            return DbSet.Where(h =>
                h.SchoolName.Contains(query) ||
                (isDate && DbFunctions.TruncateTime(h.DateOfEntry) == DbFunctions.TruncateTime(parsedDate))
            ).ToList();
        }
    }
}