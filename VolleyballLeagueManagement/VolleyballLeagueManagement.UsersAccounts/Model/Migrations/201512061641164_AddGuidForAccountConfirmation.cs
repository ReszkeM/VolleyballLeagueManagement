namespace VolleyballLeagueManagement.UsersAccounts.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGuidForAccountConfirmation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "ConfirmGuid", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "ConfirmGuid");
        }
    }
}
