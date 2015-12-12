using System;
using System.Data.Entity.Migrations;

namespace VolleyballLeagueManagement.League.Model.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<LeagueDataContext>
    {
        /*Update-Database -configuration Lgbs.Recruitment.Model.Exercises.Migrations.Configuration -Verbose*/
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Model\Migrations";
            ContextKey = "VolleyballLeagueManagement.League.Model.Migrations.Configuration";
        }

        protected override void Seed(LeagueDataContext context)
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
