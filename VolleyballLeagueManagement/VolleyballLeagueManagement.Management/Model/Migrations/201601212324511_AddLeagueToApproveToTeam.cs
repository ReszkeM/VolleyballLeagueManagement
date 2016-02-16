namespace VolleyballLeagueManagement.Management.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLeagueToApproveToTeam : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Teams", name: "League_Id", newName: "LeagueToApprove_Id");
            RenameIndex(table: "dbo.Teams", name: "IX_League_Id", newName: "IX_LeagueToApprove_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Teams", name: "IX_LeagueToApprove_Id", newName: "IX_League_Id");
            RenameColumn(table: "dbo.Teams", name: "LeagueToApprove_Id", newName: "League_Id");
        }
    }
}
