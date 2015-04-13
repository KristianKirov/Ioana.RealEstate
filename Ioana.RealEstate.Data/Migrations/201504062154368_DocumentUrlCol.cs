namespace Ioana.RealEstate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DocumentUrlCol : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Documents", "Url", c => c.String(nullable: false, maxLength: 256));
            CreateIndex("dbo.Documents", "Url", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Documents", new[] { "Url" });
            AlterColumn("dbo.Documents", "Url", c => c.String(nullable: false));
        }
    }
}
