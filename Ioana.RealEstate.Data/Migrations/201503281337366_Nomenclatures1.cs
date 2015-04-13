namespace Ioana.RealEstate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nomenclatures1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "nomenclatures.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "nomenclatures.CityRegions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        CityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("nomenclatures.Cities", t => t.CityId, cascadeDelete: true)
                .Index(t => t.CityId);
            
            CreateTable(
                "nomenclatures.OfferType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("nomenclatures.CityRegions", "CityId", "nomenclatures.Cities");
            DropIndex("nomenclatures.CityRegions", new[] { "CityId" });
            DropTable("nomenclatures.OfferType");
            DropTable("nomenclatures.CityRegions");
            DropTable("nomenclatures.Cities");
        }
    }
}
