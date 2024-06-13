using _4_BusinessObjectModel;
using System.Data.Entity;

namespace _3_DataAccess
{
    public class TuxContext : DbContext
    {
        public TuxContext() : base("name=MvcHelloworldApp")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<HighSchoolLearner> HighSchoolLearners { get; set; }
        public DbSet<StudentLearner> StudentLearners { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("t_users")
                .HasKey(u => u.Id)
                .HasMany(ur => ur.UserRoles)
                .WithRequired(ur => ur.User)
                .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<HighSchoolLearner>()
                .Map<HighSchoolLearner>(m => m.Requires("Type").HasValue("Highschool"));

            modelBuilder.Entity<StudentLearner>()
                .Map<StudentLearner>(m => m.Requires("Type").HasValue("Student"));

            modelBuilder.Entity<Role>()
                .ToTable("t_roles")
                .HasKey(r => r.RoleId)
                .HasMany(ur => ur.UserRoles)
                .WithRequired(ur => ur.Role)
                .HasForeignKey(ur => ur.RoleId);

            modelBuilder.Entity<UserRole>()
                .ToTable("t_userroles")
                .HasKey(ur => new { ur.UserId, ur.RoleId });

            base.OnModelCreating(modelBuilder);
        }
    }
}