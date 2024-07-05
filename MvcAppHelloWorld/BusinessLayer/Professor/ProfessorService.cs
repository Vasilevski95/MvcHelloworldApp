using _3_DataAccess.Generic;
using _4_BusinessObjectModel;
using BusinessLayer.Generic;

namespace BusinessLayer.Professor
{
    public class ProfessorService : GenericService<ProfessorModel>, IProfessorService
    {
        public ProfessorService(IGenericRepository<ProfessorModel> repository) : base(repository) { }
    }
}
