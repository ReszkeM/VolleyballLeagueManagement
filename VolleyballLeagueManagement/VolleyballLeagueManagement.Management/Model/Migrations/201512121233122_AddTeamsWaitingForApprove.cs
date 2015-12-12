namespace VolleyballLeagueManagement.Management.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeamsWaitingForApprove : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "League_Id", c => c.Int());
            CreateIndex("dbo.Teams", "League_Id");
            AddForeignKey("dbo.Teams", "League_Id", "dbo.Leagues", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Teams", "League_Id", "dbo.Leagues");
            DropIndex("dbo.Teams", new[] { "League_Id" });
            DropColumn("dbo.Teams", "League_Id");
        }
    }
}
