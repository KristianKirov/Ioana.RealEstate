namespace Ioana.RealEstate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nomenclatures6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "nomenclatures.Currencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("nomenclatures.Currencies");
        }
    }
}
