using System.Data.Entity;

namespace DataAccess
{
    public class TuxContext : DbContext
    {
        public TuxContext() : base("name=TuxDatabase")
        {
            Configuration.LazyLoadingEnabled = true;
        }
    }
}
