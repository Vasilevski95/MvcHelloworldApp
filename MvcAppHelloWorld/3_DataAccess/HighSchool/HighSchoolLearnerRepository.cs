using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using _4_BusinessObjectModel;

namespace _3_DataAccess.HighSchool
{
    public class HighSchoolLearnerRepository : IHighSchoolLearnerRepository
    {
        private readonly TuxContext _context;
        private readonly DbSet<HighSchoolLearner> _dbSet;
        private readonly IRoleRepository _roleRepository;

        public HighSchoolLearnerRepository(TuxContext context, IRoleRepository roleRepository)
        {
            _context = context;
            _dbSet = context.Set<HighSchoolLearner>();
            _roleRepository = roleRepository;
        }

        public void Add(HighSchoolLearner highSchoolLearner)
        {
            highSchoolLearner.Id = Guid.NewGuid();
            _dbSet.Add(highSchoolLearner);
            var role = _roleRepository.GetByName("HighSchoolLearner");
            if (role != null)
            {
                _context.UserRoles.Add(new UserRole
                {
                    UserId = highSchoolLearner.Id,
                    RoleId = role.RoleId
                });
            }
            _context.SaveChanges();
        }

        public void Update(HighSchoolLearner highSchoolLearner)
        {
            _context.Entry(highSchoolLearner).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var learner = _dbSet.Find(id);
            if (learner == null) return;

            var userRoles = _context.UserRoles.Where(ur => ur.UserId == id).ToList();
            if (userRoles.Any())
            {
                _context.UserRoles.RemoveRange(userRoles);
            }

            _dbSet.Remove(learner);
            _context.SaveChanges();
        }

        public HighSchoolLearner GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public List<HighSchoolLearner> GetAll()
        {
            return _dbSet.ToList();
        }
        
        public List<HighSchoolLearner> SearchHighSchoolLearners(string searchTerm)
        {
            var isDate = DateTime.TryParse(searchTerm, out var parsedDate);
    
            return _dbSet.Where(h =>
                h.Name.Contains(searchTerm) ||
                h.Surname.Contains(searchTerm) ||
                (isDate && DbFunctions.TruncateTime(h.DateOfBirth) == DbFunctions.TruncateTime(parsedDate)) ||
                h.Email.Contains(searchTerm) ||
                h.Phone.Contains(searchTerm) ||
                h.Address.Contains(searchTerm) ||
                h.SchoolName.Contains(searchTerm) ||
                (isDate && DbFunctions.TruncateTime(h.DateOfEntry) == DbFunctions.TruncateTime(parsedDate))
            ).ToList();
        }


    }
}
