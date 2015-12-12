namespace VolleyballLeagueManagement.League.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGamesDay : DbMigration
    {
        public override void Up()
        {
//            AddColumn("dbo.Regulations", "Days", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
//            DropColumn("dbo.Regulations", "Days");
        }
    }
}
