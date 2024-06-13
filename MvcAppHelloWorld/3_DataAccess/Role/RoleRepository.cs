using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using _4_BusinessObjectModel;

namespace _3_DataAccess
{
    public class RoleRepository : IRoleRepository
    {
        private readonly TuxContext _context;
        private readonly DbSet<Role> _dbSet;

        public RoleRepository(TuxContext context)
        {
            _context = context;
            _dbSet = context.Set<Role>();
        }

        public List<Role> GetAll()
        {
            return _dbSet.ToList();
        }

        public Role GetByName(string roleName)
        {
            return _dbSet.FirstOrDefault(r => r.RoleName == roleName);
        }
    }
}