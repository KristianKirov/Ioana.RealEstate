namespace Ioana.RealEstate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhoneClientIndexUpdate : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ClientPhones", new[] { "ClientId" });
            CreateIndex("dbo.ClientPhones", "ClientId", clustered: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.ClientPhones", new[] { "ClientId" });
            CreateIndex("dbo.ClientPhones", "ClientId", unique: true, clustered: true);
        }
    }
}
