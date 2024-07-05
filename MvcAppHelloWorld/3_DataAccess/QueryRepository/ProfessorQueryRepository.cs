using _3_DataAccess.Generic;
using _3_DataAccess.QueryModels;
using System.Collections.Generic;
using System.Linq;

namespace _3_DataAccess.QueryRepository
{
    public class ProfessorQueryRepository : GenericRepository<ProfessorQueryModel>
    {
        public ProfessorQueryRepository(TuxContext context) : base(context) { }

        public override List<ProfessorQueryModel> GetAll()
        {
            var query = @"
            SELECT Id as UserId, Name, Surname, DateOfBirth, ClassSubject, Cabinet
            FROM t_users
            WHERE Type = 'Professor'";
            return _context.Database.SqlQuery<ProfessorQueryModel>(query).ToList();
        }

        public override List<ProfessorQueryModel> Search(string searchTerm)
        {
            var searchTermLower = searchTerm.ToLower();
            return GetAll().Where(p => p.Name.ToLower().Contains(searchTermLower) ||
                                       p.Surname.ToLower().Contains(searchTermLower) ||
                                       p.ClassSubject.ToLower().Contains(searchTermLower) ||
                                       p.Cabinet.ToLower().Contains(searchTermLower) ||
                                       p.DateOfBirth.ToString("dd/MM/yyyy").ToLower().Contains(searchTermLower)).ToList();
        }
    }
}