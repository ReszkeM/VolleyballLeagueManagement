namespace VolleyballLeagueManagement.Management.Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableOrderRules : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TableOrderRules",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        RegulationsId = c.Int(nullable: false),
                        FirstRule = c.Int(nullable: false),
                        SecondRule = c.Int(nullable: false),
                        ThirdRule = c.Int(nullable: false),
                        FourthRule = c.Int(nullable: false),
                        FifthRule = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Regulations", t => t.Id, cascadeDelete: true)
                .Index(t => t.Id);
            
            AddColumn("dbo.Regulations", "TableOrderRulesId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TableOrderRules", "Id", "dbo.Regulations");
            DropIndex("dbo.TableOrderRules", new[] { "Id" });
            DropColumn("dbo.Regulations", "TableOrderRulesId");
            DropTable("dbo.TableOrderRules");
        }
    }
}
