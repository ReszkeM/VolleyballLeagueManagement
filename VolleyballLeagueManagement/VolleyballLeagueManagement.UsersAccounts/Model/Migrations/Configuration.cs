using System.Data.Entity.Migrations;

namespace VolleyballLeagueManagement.UsersAccounts.Model.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<UserAccountDataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Model\Migrations";
            ContextKey = "VolleyballLeagueManagement.UsersAccounts.Model.Migrations.Configuration";
        }

        protected override void Seed(UserAccountDataContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
