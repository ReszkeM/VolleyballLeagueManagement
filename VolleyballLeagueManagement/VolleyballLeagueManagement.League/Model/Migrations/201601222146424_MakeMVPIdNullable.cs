namespace VolleyballLeagueManagement.League.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeMVPIdNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Games", "MVPId", "dbo.Players");
            DropIndex("dbo.Games", new[] { "MVPId" });
            AlterColumn("dbo.Games", "MVPId", c => c.Int());
            CreateIndex("dbo.Games", "MVPId");
            AddForeignKey("dbo.Games", "MVPId", "dbo.Players", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Games", "MVPId", "dbo.Players");
            DropIndex("dbo.Games", new[] { "MVPId" });
            AlterColumn("dbo.Games", "MVPId", c => c.Int(nullable: false));
            CreateIndex("dbo.Games", "MVPId");
            AddForeignKey("dbo.Games", "MVPId", "dbo.Players", "Id", cascadeDelete: true);
        }
    }
}
