namespace Ioana.RealEstate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nomenclatures3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "nomenclatures.ConstructionStatuses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "nomenclatures.ConstructionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "nomenclatures.FurnishingTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("nomenclatures.FurnishingTypes");
            DropTable("nomenclatures.ConstructionTypes");
            DropTable("nomenclatures.ConstructionStatuses");
        }
    }
}
