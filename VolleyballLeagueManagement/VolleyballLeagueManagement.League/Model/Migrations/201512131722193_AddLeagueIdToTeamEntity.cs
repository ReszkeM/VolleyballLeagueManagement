namespace VolleyballLeagueManagement.League.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLeagueIdToTeamEntity : DbMigration
    {
        public override void Up()
        {
//            RenameColumn(table: "dbo.Teams", name: "League_Id", newName: "LeagueId");
//            RenameIndex(table: "dbo.Teams", name: "IX_League_Id", newName: "IX_LeagueId");
        }
        
        public override void Down()
        {
//            RenameIndex(table: "dbo.Teams", name: "IX_LeagueId", newName: "IX_League_Id");
//            RenameColumn(table: "dbo.Teams", name: "LeagueId", newName: "League_Id");
        }
    }
}
