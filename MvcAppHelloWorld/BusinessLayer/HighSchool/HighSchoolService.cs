using _3_DataAccess.Generic;
using _4_BusinessObjectModel;
using BusinessLayer.Generic;

namespace BusinessLayer.HighSchool
{
    public class HighSchoolService : GenericService<HighSchoolLearner>, IHighSchoolService
    {
        public HighSchoolService(IGenericRepository<HighSchoolLearner> repository) : base(repository) { }
    }
}