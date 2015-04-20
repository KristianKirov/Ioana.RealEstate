using Ioana.RealEstate.Converters;
using Ioana.RealEstate.Models;
using Ioana.RealEstate.Models.Nomenclatures;
using Ioana.RealEstate.Providers;
using Ioana.RealEstate.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Ioana.RealEstate.Factories
{
    public class OfferIndexDocumentFactory
    {
        public async Task<OfferIndexDocument> CreateFromInsertModel(InsertEstateModel estateModel)
        {
            IDataProvider<OfferTypeModel> offerTypesProvider = new OfferTypesDataProvider();
            IDataProvider<EstateTypeModel> estateTypesProvider = new EstateTypesDataProvider();
            IDataProvider<FurnishingTypeModel> furnishingTypesProvider = new FurnishingTypesDataProvider();
            IDataProvider<ConstructionStatusModel> constructionStatusesProvider = new ConstructionStatusesDataProvider();
            IDataProvider<ConstructionTypeModel> constructionTypesProvider = new ConstructionTypesDataProvider();
            IDataProvider<HeatingInstallationModel> heatingInstallationsProvider = new HeatingInstallationsDataProvider();
            IDataProvider<FlooringTypeModel> flooringTypesProvider = new FlooringTypesDataProvider();
            IDataProvider<JoineryTypeModel> joineryTypesProvider = new JoineryTypesDataProvider();
            IDataProvider<OfferStatusModel> offerStatusesProvider = new OfferStatusesDataProvider();
            IDataProvider<CityModel> citiesProvider = new CitiesDataProvider();
            IDataProvider<CityRegionModel> cityRegionsProvider = new CityRegionsDataProvider();
            ClientDataProvider clientDataProvider = new ClientDataProvider();
            IDataProvider<UserModel> usersDataProvider = new UsersDataProvider();

            Task<OfferTypeModel> getOfferTypeTask = offerTypesProvider.GetById(estateModel.OfferType.Id);
            Task<EstateTypeModel> getEstateTypeTask = estateTypesProvider.GetById(estateModel.EstateType.Id);
            Task<FurnishingTypeModel[]> getFurnishingTypesTask = furnishingTypesProvider.GetByIds(estateModel.FurnishingTypes.SelectedIds);
            Task<ConstructionStatusModel> getConstructionStatusTask = constructionStatusesProvider.GetById(estateModel.ConstructionStatus.Id);
            Task<ConstructionTypeModel> getConstructionTypeTask = constructionTypesProvider.GetById(estateModel.ConstructionType.Id);
            Task<HeatingInstallationModel[]> getHeatingInstallationsTask = heatingInstallationsProvider.GetByIds(estateModel.HeatingInstallations.SelectedIds);
            Task<JoineryTypeModel> getJoineryTypeTask = joineryTypesProvider.GetById(estateModel.JoineryType.Id);
            Task<FlooringTypeModel> getFlooringTypeTask = null;
            if (estateModel.FlooringType.Id != null)
            {
                getFlooringTypeTask = flooringTypesProvider.GetById(estateModel.FlooringType.Id.Value);
            }
            Task<CityModel> getCityTask = citiesProvider.GetById(estateModel.City.Id);
            Task<CityRegionModel> getCityRegionTask = cityRegionsProvider.GetById(estateModel.CityRegion.Id);
            Task<OfferStatusModel> getOfferStatusTask = offerStatusesProvider.GetById(estateModel.EstateStatusId.Value);
            Task<string[]> getClientPhonesTask = clientDataProvider.GetClientPhones(estateModel.Owner.Id.Value);
            Task<UserModel> getResponsibleTask = null;
            if (estateModel.User.Id != null)
            {
                getResponsibleTask = usersDataProvider.GetById(estateModel.User.Id.Value);
            }

            OfferIndexDocument offerIndexDocument = new OfferIndexDocument()
            {
                Id = estateModel.Id.Value,
                DisplayCurrencyId = estateModel.Currency.Id,
                YearOfConstruction = estateModel.YearOfConstruction,
                Floor = estateModel.Floor.Value,
                HasElevator = estateModel.HasElevator,
                HasParkingSpot = estateModel.HasParkingSpot,
                HasGarage = estateModel.HasGarage,
                HasParkingLot = estateModel.HasParkingLot,
                Area = estateModel.Area.Value,
                DateCreated = estateModel.DateCreated.Value
            };

            CurrencyConverter currencyConverter = new CurrencyConverter();
            offerIndexDocument.Price = currencyConverter.ToDefaultCurrency(estateModel.Price.Value, estateModel.Currency.Id);
            offerIndexDocument.OfferType = (await getOfferTypeTask).Name;
            offerIndexDocument.City = (await getCityTask).Name;
            offerIndexDocument.CityRegion = (await getCityRegionTask).Name;
            offerIndexDocument.EstateType = (await getEstateTypeTask).Name;
            offerIndexDocument.FurnishingTypes = (await getFurnishingTypesTask).Select(ft => ft.Name).ToArray();
            offerIndexDocument.ConstructionStatus = (await getConstructionStatusTask).Name;
            offerIndexDocument.ConstructionType = (await getConstructionTypeTask).Name;
            offerIndexDocument.JoineryType = (await getJoineryTypeTask).Name;
            if (getFlooringTypeTask != null)
            {
                offerIndexDocument.FlooringType = (await getFlooringTypeTask).Name;
            }
            offerIndexDocument.HeatingInstallations = (await getHeatingInstallationsTask).Select(hi => hi.Name).ToArray();
            offerIndexDocument.Status = (await getOfferStatusTask).Name;
            offerIndexDocument.PhoneNumbers = await getClientPhonesTask;
            if (getResponsibleTask != null)
            {
                offerIndexDocument.Responsible = (await getResponsibleTask).FullName;
            }

            return offerIndexDocument;
        }
    }
}