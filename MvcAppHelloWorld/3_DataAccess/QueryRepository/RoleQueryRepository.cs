using System.Collections.Generic;
using System.Linq;
using _3_DataAccess.Generic;
using _3_DataAccess.QueryModels;

namespace _3_DataAccess.QueryRepository
{
    public class RoleQueryRepository : GenericRepository<RoleQueryModel>
    {
        public RoleQueryRepository(TuxContext context) : base(context)
        {
        }

        public override List<RoleQueryModel> GetAll()
        {
            var query = @"
                SELECT RoleId, RoleName
                FROM t_roles";

            return _context.Database.SqlQuery<RoleQueryModel>(query).ToList();
        }

        public override List<RoleQueryModel> Search(string searchTerm)
        {
            return GetAll().Where(r => r.RoleName.Contains(searchTerm)).ToList();
        }
    }
}