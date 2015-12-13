namespace VolleyballLeagueManagement.League.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGameForeginKeysToTeams : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "FirstTeam_Id", "dbo.Teams");
            DropForeignKey("dbo.Games", "SecondTeam_Id", "dbo.Teams");
            DropIndex("dbo.Games", new[] { "FirstTeam_Id" });
            DropIndex("dbo.Games", new[] { "SecondTeam_Id" });
            RenameColumn(table: "dbo.Games", name: "FirstTeam_Id", newName: "FirstTeamId");
            RenameColumn(table: "dbo.Games", name: "SecondTeam_Id", newName: "SecondTeamId");
            AlterColumn("dbo.Games", "FirstTeamId", c => c.Int(nullable: false));
            AlterColumn("dbo.Games", "SecondTeamId", c => c.Int(nullable: false));
            CreateIndex("dbo.Games", "FirstTeamId");
            CreateIndex("dbo.Games", "SecondTeamId");
            AddForeignKey("dbo.Games", "FirstTeamId", "dbo.Teams", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Games", "SecondTeamId", "dbo.Teams", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "SecondTeamId", "dbo.Teams");
            DropForeignKey("dbo.Games", "FirstTeamId", "dbo.Teams");
            DropIndex("dbo.Games", new[] { "SecondTeamId" });
            DropIndex("dbo.Games", new[] { "FirstTeamId" });
            AlterColumn("dbo.Games", "SecondTeamId", c => c.Int());
            AlterColumn("dbo.Games", "FirstTeamId", c => c.Int());
            RenameColumn(table: "dbo.Games", name: "SecondTeamId", newName: "SecondTeam_Id");
            RenameColumn(table: "dbo.Games", name: "FirstTeamId", newName: "FirstTeam_Id");
            CreateIndex("dbo.Games", "SecondTeam_Id");
            CreateIndex("dbo.Games", "FirstTeam_Id");
            AddForeignKey("dbo.Games", "SecondTeam_Id", "dbo.Teams", "Id");
            AddForeignKey("dbo.Games", "FirstTeam_Id", "dbo.Teams", "Id");
        }
    }
}
