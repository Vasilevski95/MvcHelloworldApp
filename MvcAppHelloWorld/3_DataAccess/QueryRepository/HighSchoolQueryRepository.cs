using _3_DataAccess.Generic;
using _3_DataAccess.QueryModels;
using System.Collections.Generic;
using System.Linq;

namespace _3_DataAccess.QueryRepository
{
    public class HighSchoolQueryRepository : GenericRepository<HighSchoolQueryModel>
    {
        public HighSchoolQueryRepository(TuxContext context) : base(context) { }

        public override List<HighSchoolQueryModel> GetAll()
        {
            var query = @"
            SELECT Id as UserId, Name, Surname, DateOfBirth, SchoolName, DateOfEntry
            FROM t_users
            WHERE Type = 'Highschool'";
            return _context.Database.SqlQuery<HighSchoolQueryModel>(query).ToList();
        }

        public override List<HighSchoolQueryModel> Search(string searchTerm)
        {
            var searchTermLower = searchTerm.ToLower();
            return GetAll().Where(s => s.Name.ToLower().Contains(searchTermLower) ||
                                       s.Surname.ToLower().Contains(searchTermLower) ||
                                       s.SchoolName.ToLower().Contains(searchTermLower) ||
                                       s.DateOfBirth.ToString("dd/MM/yyyy").ToLower().Contains(searchTermLower) ||
                                       s.DateOfEntry.ToString("dd/MM/yyyy").ToLower().Contains(searchTermLower)).ToList();
        }
    }
}