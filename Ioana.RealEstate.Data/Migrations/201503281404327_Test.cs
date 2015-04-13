namespace Ioana.RealEstate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            AlterColumn("nomenclatures.OfferType", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("nomenclatures.OfferType", "Name", c => c.String(nullable: false, maxLength: 40));
        }
    }
}
