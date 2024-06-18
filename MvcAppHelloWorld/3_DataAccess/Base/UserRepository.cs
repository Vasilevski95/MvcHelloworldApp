using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using _4_BusinessObjectModel;

namespace _3_DataAccess.Generic
{
    public abstract class UserRepositoryBase<TEntity> : GenericRepository<TEntity>, IUserRepository where TEntity : User
    {
        public UserRepositoryBase(TuxContext context) : base(context)
        {
        }

        public override List<TEntity> Search(string searchTerm)
        {
            var isDate = DateTime.TryParse(searchTerm, out var parsedDate);

            var filteredResults = DbSet.Where(u =>
                u.Name.Contains(searchTerm) ||
                u.Surname.Contains(searchTerm) ||
                (isDate && DbFunctions.TruncateTime(u.DateOfBirth) == DbFunctions.TruncateTime(parsedDate)) ||
                u.Email.Contains(searchTerm) ||
                u.Phone.Contains(searchTerm) ||
                u.Address.Contains(searchTerm)
            ).ToList();

            var additionalResults = AdditionalSearchCondition(searchTerm, isDate, parsedDate);

            filteredResults.AddRange(additionalResults.Where(item => !filteredResults.Contains(item)));
            
            return filteredResults;
        }

        protected virtual List<TEntity> AdditionalSearchCondition(string searchTerm, bool isDate, DateTime parsedDate)
        {
            return new List<TEntity>();
        }
    }
}