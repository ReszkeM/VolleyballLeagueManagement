namespace VolleyballLeagueManagement.UsersAccounts.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePasswordConfirmation : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "PasswordRepeat");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "PasswordRepeat", c => c.String());
        }
    }
}
