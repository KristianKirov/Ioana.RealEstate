namespace Ioana.RealEstate.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OfferEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EstateOffers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OfferTypeId = c.Int(nullable: false),
                        IsShortTermRent = c.Boolean(),
                        EstateTypeId = c.Int(nullable: false),
                        Floor = c.Int(nullable: false),
                        TotalFloors = c.Int(),
                        Area = c.Double(nullable: false),
                        ConstructionStatusId = c.Int(nullable: false),
                        ConstructionTypeId = c.Int(nullable: false),
                        YearOfConstruction = c.Int(),
                        HasElevator = c.Boolean(nullable: false),
                        JoineryTypeId = c.Int(nullable: false),
                        FlooringTypeId = c.Int(),
                        HasParkingSpot = c.Boolean(nullable: false),
                        HasGarage = c.Boolean(nullable: false),
                        HasParkingLot = c.Boolean(nullable: false),
                        Description = c.String(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrencyId = c.Int(nullable: false),
                        HasCommision = c.Boolean(nullable: false),
                        CommisionNotes = c.String(),
                        AcceptsPics = c.Boolean(nullable: false),
                        CityId = c.Int(nullable: false),
                        CityRegionId = c.Int(nullable: false),
                        Street = c.String(nullable: false),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                        OwnerId = c.Int(nullable: false),
                        Called = c.Boolean(nullable: false),
                        ResponsibleId = c.Int(),
                        DateCreated = c.DateTime(nullable: false),
                        LastModifiedById = c.Int(nullable: false),
                        LastModifiedDate = c.DateTime(nullable: false),
                        StatusId = c.Int(nullable: false),
                        RealEstateUser_Id = c.Int(),
                        RealEstateUser_Id1 = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.RealEstateUser_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.RealEstateUser_Id1)
                .ForeignKey("nomenclatures.Cities", t => t.CityId)
                .ForeignKey("nomenclatures.CityRegions", t => t.CityRegionId)
                .ForeignKey("nomenclatures.ConstructionStatuses", t => t.ConstructionStatusId)
                .ForeignKey("nomenclatures.ConstructionTypes", t => t.ConstructionTypeId)
                .ForeignKey("nomenclatures.Currencies", t => t.CurrencyId)
                .ForeignKey("nomenclatures.EstateTypes", t => t.EstateTypeId)
                .ForeignKey("nomenclatures.FlooringTypes", t => t.FlooringTypeId)
                .ForeignKey("nomenclatures.JoineryTypes", t => t.JoineryTypeId)
                .ForeignKey("dbo.AspNetUsers", t => t.LastModifiedById)
                .ForeignKey("nomenclatures.OfferType", t => t.OfferTypeId)
                .ForeignKey("dbo.Clients", t => t.OwnerId)
                .ForeignKey("dbo.AspNetUsers", t => t.ResponsibleId)
                .ForeignKey("nomenclatures.OfferStatuses", t => t.StatusId)
                .Index(t => t.OfferTypeId)
                .Index(t => t.EstateTypeId)
                .Index(t => t.ConstructionStatusId)
                .Index(t => t.ConstructionTypeId)
                .Index(t => t.JoineryTypeId)
                .Index(t => t.FlooringTypeId)
                .Index(t => t.CurrencyId)
                .Index(t => t.CityId)
                .Index(t => t.CityRegionId)
                .Index(t => t.OwnerId)
                .Index(t => t.ResponsibleId)
                .Index(t => t.LastModifiedById)
                .Index(t => t.StatusId)
                .Index(t => t.RealEstateUser_Id)
                .Index(t => t.RealEstateUser_Id1);
            
            CreateTable(
                "dbo.CallHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OfferId = c.Int(nullable: false),
                        Comment = c.String(),
                        CallerId = c.Int(nullable: false),
                        CallTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id, clustered: false)
                .ForeignKey("dbo.AspNetUsers", t => t.CallerId)
                .ForeignKey("dbo.EstateOffers", t => t.OfferId)
                .Index(t => t.OfferId, clustered: true)
                .Index(t => t.CallerId);
            
            CreateTable(
                "dbo.Documents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ContentType = c.String(nullable: false),
                        Url = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OfferStatusHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OfferId = c.Int(nullable: false),
                        NewStatusId = c.Int(nullable: false),
                        OldStatusId = c.Int(nullable: false),
                        Comment = c.String(),
                        ChangeTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("nomenclatures.OfferStatuses", t => t.NewStatusId)
                .ForeignKey("dbo.EstateOffers", t => t.OfferId)
                .ForeignKey("nomenclatures.OfferStatuses", t => t.OldStatusId)
                .Index(t => t.OfferId)
                .Index(t => t.NewStatusId)
                .Index(t => t.OldStatusId);
            
            CreateTable(
                "dbo.EstateCharacteristicEstateOffers",
                c => new
                    {
                        EstateCharacteristic_Id = c.Int(nullable: false),
                        EstateOffer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.EstateCharacteristic_Id, t.EstateOffer_Id })
                .ForeignKey("nomenclatures.EstateCharacteristics", t => t.EstateCharacteristic_Id)
                .ForeignKey("dbo.EstateOffers", t => t.EstateOffer_Id)
                .Index(t => t.EstateCharacteristic_Id)
                .Index(t => t.EstateOffer_Id);
            
            CreateTable(
                "dbo.FurnishingTypeEstateOffers",
                c => new
                    {
                        FurnishingType_Id = c.Int(nullable: false),
                        EstateOffer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FurnishingType_Id, t.EstateOffer_Id })
                .ForeignKey("nomenclatures.FurnishingTypes", t => t.FurnishingType_Id)
                .ForeignKey("dbo.EstateOffers", t => t.EstateOffer_Id)
                .Index(t => t.FurnishingType_Id)
                .Index(t => t.EstateOffer_Id);
            
            CreateTable(
                "dbo.HeatingInstallationEstateOffers",
                c => new
                    {
                        HeatingInstallation_Id = c.Int(nullable: false),
                        EstateOffer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HeatingInstallation_Id, t.EstateOffer_Id })
                .ForeignKey("nomenclatures.HeatingInstallations", t => t.HeatingInstallation_Id)
                .ForeignKey("dbo.EstateOffers", t => t.EstateOffer_Id)
                .Index(t => t.HeatingInstallation_Id)
                .Index(t => t.EstateOffer_Id);
            
            CreateTable(
                "dbo.DocumentEstateOffers",
                c => new
                    {
                        Document_Id = c.Int(nullable: false),
                        EstateOffer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Document_Id, t.EstateOffer_Id })
                .ForeignKey("dbo.Documents", t => t.Document_Id)
                .ForeignKey("dbo.EstateOffers", t => t.EstateOffer_Id)
                .Index(t => t.Document_Id)
                .Index(t => t.EstateOffer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OfferStatusHistories", "OldStatusId", "nomenclatures.OfferStatuses");
            DropForeignKey("dbo.OfferStatusHistories", "OfferId", "dbo.EstateOffers");
            DropForeignKey("dbo.OfferStatusHistories", "NewStatusId", "nomenclatures.OfferStatuses");
            DropForeignKey("dbo.EstateOffers", "StatusId", "nomenclatures.OfferStatuses");
            DropForeignKey("dbo.EstateOffers", "ResponsibleId", "dbo.AspNetUsers");
            DropForeignKey("dbo.EstateOffers", "OwnerId", "dbo.Clients");
            DropForeignKey("dbo.EstateOffers", "OfferTypeId", "nomenclatures.OfferType");
            DropForeignKey("dbo.EstateOffers", "LastModifiedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.EstateOffers", "JoineryTypeId", "nomenclatures.JoineryTypes");
            DropForeignKey("dbo.DocumentEstateOffers", "EstateOffer_Id", "dbo.EstateOffers");
            DropForeignKey("dbo.DocumentEstateOffers", "Document_Id", "dbo.Documents");
            DropForeignKey("dbo.HeatingInstallationEstateOffers", "EstateOffer_Id", "dbo.EstateOffers");
            DropForeignKey("dbo.HeatingInstallationEstateOffers", "HeatingInstallation_Id", "nomenclatures.HeatingInstallations");
            DropForeignKey("dbo.FurnishingTypeEstateOffers", "EstateOffer_Id", "dbo.EstateOffers");
            DropForeignKey("dbo.FurnishingTypeEstateOffers", "FurnishingType_Id", "nomenclatures.FurnishingTypes");
            DropForeignKey("dbo.EstateOffers", "FlooringTypeId", "nomenclatures.FlooringTypes");
            DropForeignKey("dbo.EstateOffers", "EstateTypeId", "nomenclatures.EstateTypes");
            DropForeignKey("dbo.EstateCharacteristicEstateOffers", "EstateOffer_Id", "dbo.EstateOffers");
            DropForeignKey("dbo.EstateCharacteristicEstateOffers", "EstateCharacteristic_Id", "nomenclatures.EstateCharacteristics");
            DropForeignKey("dbo.EstateOffers", "CurrencyId", "nomenclatures.Currencies");
            DropForeignKey("dbo.EstateOffers", "ConstructionTypeId", "nomenclatures.ConstructionTypes");
            DropForeignKey("dbo.EstateOffers", "ConstructionStatusId", "nomenclatures.ConstructionStatuses");
            DropForeignKey("dbo.EstateOffers", "CityRegionId", "nomenclatures.CityRegions");
            DropForeignKey("dbo.EstateOffers", "CityId", "nomenclatures.Cities");
            DropForeignKey("dbo.CallHistories", "OfferId", "dbo.EstateOffers");
            DropForeignKey("dbo.CallHistories", "CallerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.EstateOffers", "RealEstateUser_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.EstateOffers", "RealEstateUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.DocumentEstateOffers", new[] { "EstateOffer_Id" });
            DropIndex("dbo.DocumentEstateOffers", new[] { "Document_Id" });
            DropIndex("dbo.HeatingInstallationEstateOffers", new[] { "EstateOffer_Id" });
            DropIndex("dbo.HeatingInstallationEstateOffers", new[] { "HeatingInstallation_Id" });
            DropIndex("dbo.FurnishingTypeEstateOffers", new[] { "EstateOffer_Id" });
            DropIndex("dbo.FurnishingTypeEstateOffers", new[] { "FurnishingType_Id" });
            DropIndex("dbo.EstateCharacteristicEstateOffers", new[] { "EstateOffer_Id" });
            DropIndex("dbo.EstateCharacteristicEstateOffers", new[] { "EstateCharacteristic_Id" });
            DropIndex("dbo.OfferStatusHistories", new[] { "OldStatusId" });
            DropIndex("dbo.OfferStatusHistories", new[] { "NewStatusId" });
            DropIndex("dbo.OfferStatusHistories", new[] { "OfferId" });
            DropIndex("dbo.CallHistories", new[] { "CallerId" });
            DropIndex("dbo.CallHistories", new[] { "OfferId" });
            DropIndex("dbo.EstateOffers", new[] { "RealEstateUser_Id1" });
            DropIndex("dbo.EstateOffers", new[] { "RealEstateUser_Id" });
            DropIndex("dbo.EstateOffers", new[] { "StatusId" });
            DropIndex("dbo.EstateOffers", new[] { "LastModifiedById" });
            DropIndex("dbo.EstateOffers", new[] { "ResponsibleId" });
            DropIndex("dbo.EstateOffers", new[] { "OwnerId" });
            DropIndex("dbo.EstateOffers", new[] { "CityRegionId" });
            DropIndex("dbo.EstateOffers", new[] { "CityId" });
            DropIndex("dbo.EstateOffers", new[] { "CurrencyId" });
            DropIndex("dbo.EstateOffers", new[] { "FlooringTypeId" });
            DropIndex("dbo.EstateOffers", new[] { "JoineryTypeId" });
            DropIndex("dbo.EstateOffers", new[] { "ConstructionTypeId" });
            DropIndex("dbo.EstateOffers", new[] { "ConstructionStatusId" });
            DropIndex("dbo.EstateOffers", new[] { "EstateTypeId" });
            DropIndex("dbo.EstateOffers", new[] { "OfferTypeId" });
            DropTable("dbo.DocumentEstateOffers");
            DropTable("dbo.HeatingInstallationEstateOffers");
            DropTable("dbo.FurnishingTypeEstateOffers");
            DropTable("dbo.EstateCharacteristicEstateOffers");
            DropTable("dbo.OfferStatusHistories");
            DropTable("dbo.Documents");
            DropTable("dbo.CallHistories");
            DropTable("dbo.EstateOffers");
        }
    }
}
