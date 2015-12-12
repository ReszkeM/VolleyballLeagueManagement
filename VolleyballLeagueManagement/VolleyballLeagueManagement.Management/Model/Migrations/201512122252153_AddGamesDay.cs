namespace VolleyballLeagueManagement.Management.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGamesDay : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Regulations", "Day", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Regulations", "Day");
        }
    }
}
