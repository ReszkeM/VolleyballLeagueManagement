namespace VolleyballLeagueManagement.Management.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLeagueMessages : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LeagueMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LeagueId = c.Int(nullable: false),
                        Title = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Leagues", t => t.LeagueId, cascadeDelete: true)
                .Index(t => t.LeagueId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LeagueMessages", "LeagueId", "dbo.Leagues");
            DropIndex("dbo.LeagueMessages", new[] { "LeagueId" });
            DropTable("dbo.LeagueMessages");
        }
    }
}
