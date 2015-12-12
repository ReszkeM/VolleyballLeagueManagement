namespace VolleyballLeagueManagement.Management.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailAndPhoneForCoach : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coaches", "Email", c => c.String());
            AddColumn("dbo.Coaches", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Coaches", "Phone");
            DropColumn("dbo.Coaches", "Email");
        }
    }
}
