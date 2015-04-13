namespace Ioana.RealEstate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ClientsInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ClientPhones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id, clustered: false)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId, unique: true, clustered: true);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Names = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        IsSeeking = c.Boolean(nullable: false),
                        IsOffering = c.Boolean(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ClientPhones", "ClientId", "dbo.Clients");
            DropIndex("dbo.ClientPhones", new[] { "ClientId" });
            DropTable("dbo.Clients");
            DropTable("dbo.ClientPhones");
        }
    }
}
