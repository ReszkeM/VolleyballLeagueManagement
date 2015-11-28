using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using VolleyballLeagueManagement.Common.Infrastructure;
using VolleyballLeagueManagement.UsersAccounts.Model.Migrations;

namespace VolleyballLeagueManagement.UsersAccounts.Model
{
    public class UserAccountDataContext : DbContext
    {
        static UserAccountDataContext()
        {
            Database.SetInitializer(new DatabaseInitializer<UserAccountDataContext, Configuration>());
        }

        public UserAccountDataContext() : base("VolleyballLeagueManagement.UserAccounts") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
               .Entity<User>()
               .HasRequired(r => r.Address)
               .WithRequiredPrincipal(d => d.User)
               .WillCascadeOnDelete();
        }
    }

    public class ManagementDataContextFactory : IDbContextFactory<UserAccountDataContext>
    {
        public UserAccountDataContext Create()
        {
            return new UserAccountDataContext();
        }
    }
}
