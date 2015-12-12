namespace VolleyballLeagueManagement.League.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCalendar : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Calendars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LeagueId = c.Int(nullable: false),
                        League_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Leagues", t => t.League_Id, cascadeDelete: true)
                .Index(t => t.League_Id);
            
            CreateTable(
                "dbo.Rounds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CalendarId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Number = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Calendars", t => t.CalendarId, cascadeDelete: true)
                .Index(t => t.CalendarId);
            
            CreateTable(
                "dbo.Games",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoundId = c.Int(nullable: false),
                        MVPId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        FirstTeam_Id = c.Int(),
                        SecondTeam_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.FirstTeam_Id)
                .ForeignKey("dbo.Players", t => t.MVPId, cascadeDelete: true)
                .ForeignKey("dbo.Teams", t => t.SecondTeam_Id)
                .ForeignKey("dbo.Rounds", t => t.RoundId, cascadeDelete: true)
                .Index(t => t.RoundId)
                .Index(t => t.MVPId)
                .Index(t => t.FirstTeam_Id)
                .Index(t => t.SecondTeam_Id);
            
            CreateTable(
                "dbo.Sets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GameId = c.Int(nullable: false),
                        Number = c.Int(nullable: false),
                        Time = c.Time(nullable: false, precision: 7),
                        FirstTeamPoints = c.Int(nullable: false),
                        SecondTeamPoints = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Games", t => t.GameId, cascadeDelete: true)
                .Index(t => t.GameId);
            
            AddColumn("dbo.Leagues", "CalendarId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "RoundId", "dbo.Rounds");
            DropForeignKey("dbo.Sets", "GameId", "dbo.Games");
            DropForeignKey("dbo.Games", "SecondTeam_Id", "dbo.Teams");
            DropForeignKey("dbo.Games", "MVPId", "dbo.Players");
            DropForeignKey("dbo.Games", "FirstTeam_Id", "dbo.Teams");
            DropForeignKey("dbo.Rounds", "CalendarId", "dbo.Calendars");
            DropForeignKey("dbo.Calendars", "League_Id", "dbo.Leagues");
            DropIndex("dbo.Sets", new[] { "GameId" });
            DropIndex("dbo.Games", new[] { "SecondTeam_Id" });
            DropIndex("dbo.Games", new[] { "FirstTeam_Id" });
            DropIndex("dbo.Games", new[] { "MVPId" });
            DropIndex("dbo.Games", new[] { "RoundId" });
            DropIndex("dbo.Rounds", new[] { "CalendarId" });
            DropIndex("dbo.Calendars", new[] { "League_Id" });
            DropColumn("dbo.Leagues", "CalendarId");
            DropTable("dbo.Sets");
            DropTable("dbo.Games");
            DropTable("dbo.Rounds");
            DropTable("dbo.Calendars");
        }
    }
}
