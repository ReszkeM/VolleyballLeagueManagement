namespace VolleyballLeagueManagement.League.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressIdToLeague : DbMigration
    {
        public override void Up()
        {
           // AddColumn("dbo.Leagues", "AddressId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            //DropColumn("dbo.Leagues", "AddressId");
        }
    }
}
