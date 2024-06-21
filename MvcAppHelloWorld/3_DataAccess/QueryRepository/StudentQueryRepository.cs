using System.Collections.Generic;
using System.Linq;
using _3_DataAccess.Generic;
using _3_DataAccess.QueryModels;

namespace _3_DataAccess.QueryRepository
{
    public class StudentQueryRepository : GenericRepository<StudentQueryModel>
    {
        public StudentQueryRepository(TuxContext context) : base(context)
        {
        }

        public override List<StudentQueryModel> GetAll()
        {
            var query = @"
                SELECT Id as UserId, Name, Surname, DateOfBirth, CollegeName, Generation
                FROM t_users
                WHERE Type = 'Student'";

            return _context.Database.SqlQuery<StudentQueryModel>(query).ToList();
        }

        public override List<StudentQueryModel> Search(string searchTerm)
        {
            return GetAll().Where(s => s.Name.Contains(searchTerm) ||
                                       s.Surname.Contains(searchTerm) ||
                                       s.CollegeName.Contains(searchTerm) ||
                                       s.Generation.ToString().Contains(searchTerm)).ToList();
        }
    }
}