namespace Ioana.RealEstate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientPhoneIndex : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.ClientPhones", "Phone", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.ClientPhones", new[] { "Phone" });
        }
    }
}
