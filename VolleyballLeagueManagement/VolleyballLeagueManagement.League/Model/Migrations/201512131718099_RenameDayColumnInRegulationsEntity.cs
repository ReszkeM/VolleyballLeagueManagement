namespace VolleyballLeagueManagement.League.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameDayColumnInRegulationsEntity : DbMigration
    {
        public override void Up()
        {
//            AddColumn("dbo.Regulations", "Day", c => c.Int(nullable: false));
//            DropColumn("dbo.Regulations", "Days");
        }
        
        public override void Down()
        {
//            AddColumn("dbo.Regulations", "Days", c => c.Int(nullable: false));
//            DropColumn("dbo.Regulations", "Day");
        }
    }
}
