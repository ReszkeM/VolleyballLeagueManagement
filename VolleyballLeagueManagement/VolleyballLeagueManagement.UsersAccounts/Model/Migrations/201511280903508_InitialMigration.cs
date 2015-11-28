namespace VolleyballLeagueManagement.UsersAccounts.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        City = c.String(),
                        Street = c.String(),
                        HomeNumber = c.String(),
                        FlatNumber = c.String(),
                        PostCode = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Login = c.String(),
                        Password = c.String(),
                        PasswordRepeat = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        IsAccountConfirmed = c.Boolean(nullable: false),
                        Role = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "Id", "dbo.Users");
            DropIndex("dbo.Addresses", new[] { "Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Addresses");
        }
    }
}
