using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using VolleyballLeagueManagement.Common.Infrastructure;
using VolleyballLeagueManagement.Common.Interfaces.Messaging;
using VolleyballLeagueManagement.Management.Model.Migrations;

namespace VolleyballLeagueManagement.Management.Model
{
    public class ManagementDataContext : DbContext
    {
        protected IBus bus;

        static ManagementDataContext()
        {
            Database.SetInitializer(new DatabaseInitializer<ManagementDataContext, Configuration>());
        }

        public ManagementDataContext() : base("VolleyballLeagueManagement.Management") { }

        public DbSet<League> Leagues { get; set; }
        public DbSet<LeagueNote> LeagueNotes { get; set; }
        public DbSet<Regulations> Regulationses { get; set; }
        public DbSet<TableOrderRules> TableOrderRegulationses { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<SportsHall> SportsHalls { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Coach> Coaches { get; set; }
        public DbSet<Player> Players { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<League>()
                .HasRequired(l => l.SportsHall)
                .WithRequiredPrincipal(a => a.League)
                .WillCascadeOnDelete();

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
                .Entity<Regulations>()
                .HasRequired(r => r.Document)
                .WithRequiredPrincipal(d => d.Regulations)
                .WillCascadeOnDelete();

            modelBuilder
                .Entity<Regulations>()
                .HasRequired(r => r.TableOrderRules)
                .WithRequiredPrincipal(d => d.Regulations)
                .WillCascadeOnDelete();

            modelBuilder
                .Entity<Team>()
                .HasRequired(t => t.Coach)
                .WithRequiredPrincipal(c => c.Team)
                .WillCascadeOnDelete();
        }
    }

    public class ManagementDataContextFactory : IDbContextFactory<ManagementDataContext>
    {
        public ManagementDataContext Create()
        {
            return new ManagementDataContext();
        }
    }
}
