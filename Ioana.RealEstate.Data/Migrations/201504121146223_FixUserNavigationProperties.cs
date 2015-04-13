namespace Ioana.RealEstate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixUserNavigationProperties : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EstateOffers", "RealEstateUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.EstateOffers", "LastModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.EstateOffers", "ResponsibleId", "dbo.AspNetUsers");
            DropIndex("dbo.EstateOffers", new[] { "LastModifiedById" });
            DropIndex("dbo.EstateOffers", new[] { "ResponsibleId" });
            DropIndex("dbo.EstateOffers", new[] { "RealEstateUser_Id" });
            DropIndex("dbo.EstateOffers", new[] { "RealEstateUser_Id1" });
            DropColumn("dbo.EstateOffers", "LastModifiedById");
            DropColumn("dbo.EstateOffers", "ResponsibleId");
            RenameColumn(table: "dbo.EstateOffers", name: "RealEstateUser_Id", newName: "LastModifiedById");
            RenameColumn(table: "dbo.EstateOffers", name: "RealEstateUser_Id1", newName: "ResponsibleId");
            AlterColumn("dbo.EstateOffers", "LastModifiedById", c => c.Int(nullable: false));
            CreateIndex("dbo.EstateOffers", "LastModifiedById");
            AddForeignKey("dbo.EstateOffers", "LastModifiedById", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EstateOffers", "LastModifiedById", "dbo.AspNetUsers");
            DropIndex("dbo.EstateOffers", new[] { "LastModifiedById" });
            AlterColumn("dbo.EstateOffers", "LastModifiedById", c => c.Int());
            RenameColumn(table: "dbo.EstateOffers", name: "ResponsibleId", newName: "RealEstateUser_Id1");
            RenameColumn(table: "dbo.EstateOffers", name: "LastModifiedById", newName: "RealEstateUser_Id");
            AddColumn("dbo.EstateOffers", "ResponsibleId", c => c.Int());
            AddColumn("dbo.EstateOffers", "LastModifiedById", c => c.Int(nullable: false));
            CreateIndex("dbo.EstateOffers", "RealEstateUser_Id1");
            CreateIndex("dbo.EstateOffers", "RealEstateUser_Id");
            CreateIndex("dbo.EstateOffers", "LastModifiedById");
            AddForeignKey("dbo.EstateOffers", "RealEstateUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
