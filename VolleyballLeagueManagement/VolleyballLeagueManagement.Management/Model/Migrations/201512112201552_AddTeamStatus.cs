namespace VolleyballLeagueManagement.Management.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTeamStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teams", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teams", "Status");
        }
    }
}
