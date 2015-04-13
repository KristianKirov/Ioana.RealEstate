namespace Ioana.RealEstate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserFields : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RealEstateUserPhones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id, clustered: false)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId, clustered: true)
                .Index(t => t.Phone, unique: true);
            
            AddColumn("dbo.AspNetUsers", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RealEstateUserPhones", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.RealEstateUserPhones", new[] { "Phone" });
            DropIndex("dbo.RealEstateUserPhones", new[] { "UserId" });
            DropColumn("dbo.AspNetUsers", "LastName");
            DropColumn("dbo.AspNetUsers", "FirstName");
            DropTable("dbo.RealEstateUserPhones");
        }
    }
}
