using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using _4_BusinessObjectModel;

namespace _3_DataAccess.Generic
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly TuxContext _context;
        protected readonly DbSet<TEntity> DbSet;

        public GenericRepository(TuxContext context)
        {
            _context = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            var idProperty = typeof(TEntity).GetProperty("Id");
            if (idProperty != null && idProperty.PropertyType == typeof(Guid))
            {
                idProperty.SetValue(entity, Guid.NewGuid());
            }

            DbSet.Add(entity);
            _context.SaveChanges();

            if (entity is User user)
            {
                AssignRole(user);
            }
        }

        public virtual void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual void Delete(Guid id)
        {
            var entity = DbSet.Find(id);
            if (entity == null) return;

            if (entity is User user)
            {
                RemoveUserRoles(user.Id);
            }

            DbSet.Remove(entity);
            _context.SaveChanges();
        }

        public virtual TEntity GetById(Guid id)
        {
            var entity = _context.Users.Find(id);
            return entity as TEntity;
        }

        public virtual List<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual List<TEntity> Search(string searchTerm)
        {
            return new List<TEntity>();
        }

        private void AssignRole(User user)
        {
            var roleName = GetRoleName(user);
            var role = GetRoleByName(roleName);
            if (role == null) return;

            _context.UserRoles.Add(new UserRole
            {
                UserId = user.Id,
                RoleId = role.RoleId
            });
            _context.SaveChanges();
        }

        private void RemoveUserRoles(Guid userId)
        {
            var userRoles = _context.UserRoles.Where(ur => ur.UserId == userId).ToList();
            if (!userRoles.Any()) return;
            _context.UserRoles.RemoveRange(userRoles);
            _context.SaveChanges();
        }

        protected virtual string GetRoleName(User user)
        {
            return string.Empty;
        }

        private Role GetRoleByName(string roleName)
        {
            return _context.Roles.FirstOrDefault(r => r.RoleName == roleName);
        }
    }
}