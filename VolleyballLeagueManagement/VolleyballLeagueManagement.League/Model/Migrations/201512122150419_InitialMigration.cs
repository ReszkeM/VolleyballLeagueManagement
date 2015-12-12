namespace VolleyballLeagueManagement.League.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
//            CreateTable(
//                "dbo.Leagues",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        RegulationsId = c.Int(nullable: false),
//                        OrganizerId = c.Int(nullable: false),
//                        Name = c.String(),
//                        Status = c.Int(nullable: false),
//                    })
//                .PrimaryKey(t => t.Id);
//            
//            CreateTable(
//                "dbo.Regulations",
//                c => new
//                    {
//                        Id = c.Int(nullable: false),
//                        LeagueId = c.Int(nullable: false),
//                        TableOrderRulesId = c.Int(nullable: false),
//                        Playoffs = c.Boolean(nullable: false),
//                        StartTime = c.DateTime(nullable: false),
//                        EndTime = c.DateTime(nullable: false),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("dbo.Leagues", t => t.Id, cascadeDelete: true)
//                .Index(t => t.Id);
//            
//            CreateTable(
//                "dbo.TableOrderRules",
//                c => new
//                    {
//                        Id = c.Int(nullable: false),
//                        RegulationsId = c.Int(nullable: false),
//                        FirstRule = c.Int(nullable: false),
//                        SecondRule = c.Int(nullable: false),
//                        ThirdRule = c.Int(nullable: false),
//                        FourthRule = c.Int(nullable: false),
//                        FifthRule = c.Int(nullable: false),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("dbo.Regulations", t => t.Id, cascadeDelete: true)
//                .Index(t => t.Id);
//            
//            CreateTable(
//                "dbo.Teams",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        ManagerId = c.Int(nullable: false),
//                        Name = c.String(),
//                        Status = c.Int(nullable: false),
//                        League_Id = c.Int(),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("dbo.Leagues", t => t.League_Id)
//                .Index(t => t.League_Id);
//            
//            CreateTable(
//                "dbo.Players",
//                c => new
//                    {
//                        Id = c.Int(nullable: false, identity: true),
//                        TeamId = c.Int(nullable: false),
//                        FirstName = c.String(),
//                        LastName = c.String(),
//                        IsCapitan = c.Boolean(nullable: false),
//                        Position = c.Int(nullable: false),
//                    })
//                .PrimaryKey(t => t.Id)
//                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
//                .Index(t => t.TeamId);
            
        }
        
        public override void Down()
        {
//            DropForeignKey("dbo.Teams", "League_Id", "dbo.Leagues");
//            DropForeignKey("dbo.Players", "TeamId", "dbo.Teams");
//            DropForeignKey("dbo.Regulations", "Id", "dbo.Leagues");
//            DropForeignKey("dbo.TableOrderRules", "Id", "dbo.Regulations");
//            DropIndex("dbo.Players", new[] { "TeamId" });
//            DropIndex("dbo.Teams", new[] { "League_Id" });
//            DropIndex("dbo.TableOrderRules", new[] { "Id" });
//            DropIndex("dbo.Regulations", new[] { "Id" });
//            DropTable("dbo.Players");
//            DropTable("dbo.Teams");
//            DropTable("dbo.TableOrderRules");
//            DropTable("dbo.Regulations");
//            DropTable("dbo.Leagues");
        }
    }
}
