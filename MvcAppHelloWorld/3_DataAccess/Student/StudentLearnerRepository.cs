using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using _4_BusinessObjectModel;

namespace _3_DataAccess.Student
{
    public class StudentLearnerRepository : IStudentLearnerRepository
    {
        private readonly TuxContext _context;
        private readonly DbSet<StudentLearner> _dbSet;
        private readonly IRoleRepository _roleRepository;

        public StudentLearnerRepository(TuxContext context, IRoleRepository roleRepository)
        {
            _context = context;
            _dbSet = context.Set<StudentLearner>();
            _roleRepository = roleRepository;
        }

        public void Add(StudentLearner studentLearner)
        {
            studentLearner.Id = Guid.NewGuid();
            _dbSet.Add(studentLearner);
            var role = _roleRepository.GetByName("StudentLearner");
            if (role != null)
            {
                _context.UserRoles.Add(new UserRole
                {
                    UserId = studentLearner.Id,
                    RoleId = role.RoleId
                });
            }
            _context.SaveChanges();
        }

        public void Update(StudentLearner studentLearner)
        {
            _context.Entry(studentLearner).State = EntityState.Modified;
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

        public StudentLearner GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<StudentLearner> GetAll()
        {
            return _dbSet.ToList();
        }
        
        public IEnumerable<StudentLearner> SearchStudentLearners(string searchTerm)
        {
            var isDate = DateTime.TryParse(searchTerm, out var parsedDate);
            
            return _dbSet.Where(s =>
                s.Name.Contains(searchTerm) ||
                s.Surname.Contains(searchTerm) ||
                (isDate && DbFunctions.TruncateTime(s.DateOfBirth) == DbFunctions.TruncateTime(parsedDate)) ||
                s.Email.Contains(searchTerm) ||
                s.Phone.Contains(searchTerm) ||
                s.Address.Contains(searchTerm) ||
                s.CollegeName.Contains(searchTerm) ||
                s.Generation.ToString().Contains(searchTerm)
            ).ToList();
        }

    }
}