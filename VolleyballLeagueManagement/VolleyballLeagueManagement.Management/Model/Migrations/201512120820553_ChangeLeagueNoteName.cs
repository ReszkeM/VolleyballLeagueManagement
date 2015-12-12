namespace VolleyballLeagueManagement.Management.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeLeagueNoteName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.LeagueMessages", newName: "LeagueNotes");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.LeagueNotes", newName: "LeagueMessages");
        }
    }
}
