using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using _3_DataAccess.Generic;
using _4_BusinessObjectModel;

namespace _3_DataAccess.Professor
{
    public class ProfessorRepository : UserRepositoryBase<ProfessorModel>, IProfessorRepository
    {
        public ProfessorRepository(TuxContext context) : base(context)
        {
        }

        protected override string GetRoleName(User user)
        {
            return "Professor";
        }

        protected override List<ProfessorModel> AdditionalSearchCondition(string query, bool isDate, DateTime parsedDate)
        {
            return DbSet.Where(p =>
                p.ClassSubject.Contains(query) ||
                p.Cabinet.Contains(query)
            ).ToList();
        }
    }
}