using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;

namespace VolleyballLeagueManagement.Common.Infrastructure
{
    public class DatabaseInitializer<TModel, TConfiguration> : IDatabaseInitializer<TModel>
        where TModel : DbContext
        where TConfiguration : DbMigrationsConfiguration<TModel>, new()
    {
        public void InitializeDatabase(TModel context)
        {
            DbMigrationsConfiguration configuration = new TConfiguration();
            bool dbExists = context.Database.Exists();

            if (dbExists)
            {
                bool dbUpToDate = context.Database.CompatibleWithModel(false);

                var migrator = new DbMigrator(configuration);

                if (!dbUpToDate || migrator.GetPendingMigrations().Any())
                {
                    throw new ApplicationException("Model danych został zmieniony.");
                }
            }
            else
                throw new ApplicationException("Baza danych nie istnieje.");
        }
    }
}
