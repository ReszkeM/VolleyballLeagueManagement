using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using VolleyballLeagueManagement.Common.Infrastructure;
using VolleyballLeagueManagement.Common.Interfaces.Messaging;
using VolleyballLeagueManagement.League.Model.Migrations;

namespace VolleyballLeagueManagement.League.Model
{
    public class LeagueDataContext : DbContext
    {
        protected IBus bus;

        static LeagueDataContext()
        {
            Database.SetInitializer(new DatabaseInitializer<LeagueDataContext, Configuration>());
        }

        public LeagueDataContext() : base("VolleyballLeagueManagement.League") { }

        public DbSet<League> Leagues { get; set; }
        public DbSet<Regulations> Regulationses { get; set; }
        public DbSet<TableOrderRules> TableOrderRegulationses { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<Round> Rounds { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Set> Sets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<League>()
                .HasRequired(l => l.Regulations)
                .WithRequiredPrincipal(r => r.League)
                .WillCascadeOnDelete();

            modelBuilder
                .Entity<League>()
                .HasMany(l => l.Teams)
                .WithOptional(r => r.League);

            modelBuilder
                .Entity<League>()
                .HasOptional(l => l.Calendar)
                .WithOptionalPrincipal(c => c.League)
                .WillCascadeOnDelete();

            modelBuilder
                .Entity<Regulations>()
                .HasRequired(r => r.TableOrderRules)
                .WithRequiredPrincipal(d => d.Regulations)
                .WillCascadeOnDelete();
        }
    }

    public class LeagueDataContextFactory : IDbContextFactory<LeagueDataContext>
    {
        public LeagueDataContext Create()
        {
            return new LeagueDataContext();
        }
    }
}
