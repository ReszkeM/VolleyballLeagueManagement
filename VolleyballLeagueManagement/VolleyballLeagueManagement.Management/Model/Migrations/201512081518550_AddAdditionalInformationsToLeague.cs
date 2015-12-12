namespace VolleyballLeagueManagement.Management.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAdditionalInformationsToLeague : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Leagues", "AdditionalInformations", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Leagues", "AdditionalInformations");
        }
    }
}
