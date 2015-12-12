namespace VolleyballLeagueManagement.Management.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coaches",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        TeamId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ManagerId = c.Int(nullable: false),
                        LeagueId = c.Int(),
                        CoachId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Leagues", t => t.LeagueId)
                .Index(t => t.LeagueId);
            
            CreateTable(
                "dbo.Leagues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressId = c.Int(nullable: false),
                        RegulationsId = c.Int(nullable: false),
                        OrganizerId = c.Int(nullable: false),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Regulations",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        LeagueId = c.Int(nullable: false),
                        DocumentId = c.Int(nullable: false),
                        TeamsLimit = c.Int(nullable: false),
                        PlayersLimit = c.Int(nullable: false),
                        EntryFee = c.Int(nullable: false),
                        Playoffs = c.Boolean(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        ApplicationDeadline = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Leagues", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        RegulationsId = c.Int(nullable: false),
                        MIMEType = c.String(),
                        Size = c.Int(nullable: false),
                        Content = c.Binary(),
                        Extension = c.String(maxLength: 5),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regulations", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.SportsHalls",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        LeagueId = c.Int(nullable: false),
                        City = c.String(),
                        Streat = c.String(),
                        Number = c.Int(nullable: false),
                        PostCode = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Leagues", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Players",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        IsCapitan = c.Boolean(nullable: false),
                        Age = c.Int(nullable: false),
                        Growth = c.Int(nullable: false),
                        Position = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Players", "TeamId", "dbo.Teams");
            DropForeignKey("dbo.Teams", "LeagueId", "dbo.Leagues");
            DropForeignKey("dbo.SportsHalls", "Id", "dbo.Leagues");
            DropForeignKey("dbo.Regulations", "Id", "dbo.Leagues");
            DropForeignKey("dbo.Documents", "Id", "dbo.Regulations");
            DropForeignKey("dbo.Coaches", "Id", "dbo.Teams");
            DropIndex("dbo.Players", new[] { "TeamId" });
            DropIndex("dbo.SportsHalls", new[] { "Id" });
            DropIndex("dbo.Documents", new[] { "Id" });
            DropIndex("dbo.Regulations", new[] { "Id" });
            DropIndex("dbo.Teams", new[] { "LeagueId" });
            DropIndex("dbo.Coaches", new[] { "Id" });
            DropTable("dbo.Players");
            DropTable("dbo.SportsHalls");
            DropTable("dbo.Documents");
            DropTable("dbo.Regulations");
            DropTable("dbo.Leagues");
            DropTable("dbo.Teams");
            DropTable("dbo.Coaches");
        }
    }
}
