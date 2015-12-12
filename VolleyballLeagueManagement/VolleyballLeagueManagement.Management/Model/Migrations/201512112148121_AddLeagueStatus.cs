namespace VolleyballLeagueManagement.Management.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLeagueStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leagues", "Status", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Leagues", "Status");
        }
    }
}
