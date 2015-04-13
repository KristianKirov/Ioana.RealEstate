using Ioana.RealEstate.Data.EntityFramework;
using Ioana.RealEstate.Data.EntityFramework.Extensions;
using Ioana.RealEstate.Data.Model;
using Ioana.RealEstate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Ioana.RealEstate.Providers
{
    public class EstatesOffersDataProvider
    {
        public async Task AddNewEstate(InsertEstateModel estate, int currentUserId)
        {
            EstateOffer offer = new EstateOffer();
            offer.OfferTypeId = estate.OfferType.Id;
            offer.EstateTypeId = estate.EstateType.Id;
            offer.Floor = estate.Floor.Value;
            offer.TotalFloors = estate.TotalFloors;
            offer.Area = estate.Area.Value;
            offer.ConstructionStatusId = estate.ConstructionStatus.Id;
            offer.ConstructionTypeId = estate.ConstructionType.Id;
            offer.YearOfConstruction = estate.YearOfConstruction;
            offer.HasElevator = estate.HasElevator;
            offer.JoineryTypeId = estate.JoineryType.Id;
            if (estate.FlooringType != null && estate.FlooringType.Id != null)
            {
                offer.FlooringTypeId = estate.FlooringType.Id.Value;
            }
            offer.HasParkingSpot = estate.HasParkingSpot;
            offer.HasGarage = estate.HasGarage;
            offer.HasParkingLot = estate.HasParkingLot;
            offer.Description = estate.Description;
            offer.Price = estate.Price.Value;
            offer.CurrencyId = estate.Currency.Id;
            offer.HasCommision = estate.HasCommision;
            offer.CommisionNotes = estate.CommisionNotes;
            offer.AcceptsPics = estate.AcceptsPics;
            offer.CityId = estate.City.Id;
            offer.CityRegionId = estate.CityRegion.Id;
            offer.Street = estate.Street;
            offer.Latitude = estate.Coordinates.Latitude;
            offer.Longitude = estate.Coordinates.Longitude;
            offer.OwnerId = estate.Owner.Id.Value;
            offer.Called = estate.Called.AlreadyCalled;
            if (estate.Called.AlreadyCalled)
            {
                offer.Calls = new CallHistory[]
                {
                    new CallHistory()
                    {
                        CallerId = estate.Called.Caller.Id.Value,
                        Comment = estate.Called.Comment,
                        CallTime = DateTime.UtcNow
                    }
                };
            }

            if (estate.User != null && estate.User.Id != null)
            {
                offer.ResponsibleId = estate.User.Id.Value;
            }

            offer.LastModifiedById = currentUserId;

            offer.DateCreated = offer.LastModifiedDate = DateTime.UtcNow;

            using (RealEstateDbContext dbContext = new RealEstateDbContext())
            {
                offer.FurnishingTypes = estate.FurnishingTypes.SelectedIds.Select(ft => new FurnishingType() { Id = ft }.AsExisting(dbContext)).ToArray();
                offer.HeatingInstallations = estate.HeatingInstallations.SelectedIds.Select(hi => new HeatingInstallation() { Id = hi }.AsExisting(dbContext)).ToArray();
                if (estate.EstateCharacteristics != null && estate.EstateCharacteristics.SelectedIds != null)
                {
                    offer.EstateCharacteristics = estate.EstateCharacteristics.SelectedIds.Select(ec => new EstateCharacteristic() { Id = ec }.AsExisting(dbContext)).ToArray();
                }
                if (estate.Images != null && estate.Images.ExistingImages != null)
                {
                    offer.Images = estate.Images.ExistingImages.Select(ei => new Document() { Id = ei.Id }.AsExisting(dbContext)).ToArray();
                }

                if (offer.Images != null && offer.Images.Count > 0)
                {
                    offer.StatusId = 2; // Полуактивна
                }
                else
                {
                    offer.StatusId = 4; // Нова
                }

                dbContext.Offers.Add(offer);

                await dbContext.SaveChangesAsync();

                estate.Id = offer.Id;
            }
        }
    }
}