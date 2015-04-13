namespace Ioana.RealEstate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nomenclatures4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "nomenclatures.FlooringTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "nomenclatures.HeatingInstallations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "nomenclatures.JoineryTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "nomenclatures.OfferStatuses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("nomenclatures.OfferStatuses");
            DropTable("nomenclatures.JoineryTypes");
            DropTable("nomenclatures.HeatingInstallations");
            DropTable("nomenclatures.FlooringTypes");
        }
    }
}
