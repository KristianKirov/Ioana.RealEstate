using Ioana.RealEstate.Localization;
using Ioana.RealEstate.Models.Editors;
using Ioana.RealEstate.Models.Nomenclatures;
using Ioana.RealEstate.Providers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Ioana.RealEstate.Models
{
    public class RealEstateSearchModel
    {
        public DropDownModel<OfferTypeModel, int?> OfferType { get; set; }

        public DropDownModel<CityModel, int?> City { get; set; }

        public MultiSelectModel<CityRegionModel, int> CityRegions { get; set; }

        [Range(0, int.MaxValue)]
        public decimal? PriceFrom { get; set; }

        [Range(0, int.MaxValue)]
        public decimal? PriceTo { get; set; }

        public MultiSelectModel<EstateTypeModel, int> EstateTypes { get; set; }

        public DropDownModel<FurnishingTypeModel, int?> FurnishingType { get; set; }

        public DropDownModel<ConstructionStatusModel, int?> ConstructionStatus { get; set; }

        public DropDownModel<ConstructionTypeModel, int?> ConstructionType { get; set; }

        public int? YearOfConstruction { get; set; }

        public int? FloorFrom { get; set; }

        public int? FloorTo { get; set; }

        public bool? HasElevator { get; set; }

        public MultiSelectModel<HeatingInstallationModel, int> HeatingInstallations { get; set; }

        public bool? HasParkingSpot { get; set; }

        public bool? HasGarage { get; set; }

        public bool? HasParkingLot { get; set; }

        public DropDownModel<JoineryTypeModel, int?> JoineryType { get; set; }

        public DropDownModel<FlooringTypeModel, int?> FlooringType { get; set; }

        [Range(0, int.MaxValue)]
        public double? AreaFrom { get; set; }

        [Range(0, int.MaxValue)]
        public double? AreaTo { get; set; }

        public DropDownModel<OfferStatusModel, int?> OfferStatus { get; set; }

        public string PhoneNumber { get; set; }

        [Range(1, int.MaxValue)]
        public int? OfferId { get; set; }

        public async Task Load()
        {
            IDataProvider<OfferTypeModel> offerTypesProvider = new OfferTypesDataProvider();
            IDataProvider<CityModel> citiesProvider = new CitiesDataProvider();
            IDataProvider<CityRegionModel> cityRegionsProvider = new CityRegionsDataProvider();
            IDataProvider<EstateTypeModel> estateTypesProvider = new EstateTypesDataProvider();
            IDataProvider<FurnishingTypeModel> furnishingTypesProvider = new FurnishingTypesDataProvider();
            IDataProvider<ConstructionStatusModel> constructionStatusesProvider = new ConstructionStatusesDataProvider();
            IDataProvider<ConstructionTypeModel> constructionTypesProvider = new ConstructionTypesDataProvider();
            IDataProvider<HeatingInstallationModel> heatingInstallationsProvider = new HeatingInstallationsDataProvider();
            IDataProvider<JoineryTypeModel> joineryTypesProvider = new JoineryTypesDataProvider();
            IDataProvider<FlooringTypeModel> flooringTypesProvider = new FlooringTypesDataProvider();
            IDataProvider<OfferStatusModel> offerStatusesProvider = new OfferStatusesDataProvider();

            Task<OfferTypeModel[]> getAllOfferTypesTask = offerTypesProvider.GetAll();
            Task<CityModel[]> getAllCitiesTask = citiesProvider.GetAll();
            Task<CityRegionModel[]> getAllCityRegionsTask = cityRegionsProvider.GetAll();
            Task<EstateTypeModel[]> getAllEstateTypesTask = estateTypesProvider.GetAll();
            Task<FurnishingTypeModel[]> getAllFurnishingTypesTask = furnishingTypesProvider.GetAll();
            Task<ConstructionStatusModel[]> getAllConstructionStatusesTask = constructionStatusesProvider.GetAll();
            Task<ConstructionTypeModel[]> getAllConstructionTypesTask = constructionTypesProvider.GetAll();
            Task<HeatingInstallationModel[]> getAllHeatingInstallationsTask = heatingInstallationsProvider.GetAll();
            Task<JoineryTypeModel[]> getAllJoineryTypesTask = joineryTypesProvider.GetAll();
            Task<FlooringTypeModel[]> getAllFlooringTypesTask = flooringTypesProvider.GetAll();
            Task<OfferStatusModel[]> getAllOfferStatusesTask = offerStatusesProvider.GetAll();

            if (this.OfferType == null)
            {
                this.OfferType = new DropDownModel<OfferTypeModel, int?>();
            }
            this.OfferType.OptionLabel = Resources.SelectDropDownText;
            this.OfferType.SetItems(await getAllOfferTypesTask, ot => ot.Name, ot => ot.Id);

            if (this.City == null)
            {
                this.City = new DropDownModel<CityModel, int?>();
            }
            this.City.OptionLabel = Resources.SelectDropDownText;
            this.City.SetItems(await getAllCitiesTask, c => c.Name, c => c.Id);

            if (this.CityRegions == null)
            {
                this.CityRegions = new MultiSelectModel<CityRegionModel, int>();
            }
            this.CityRegions.Placeholder = Resources.MultiselectPlaceholder;
            this.CityRegions.SetItems(await getAllCityRegionsTask, d => d.Name, d => d.Id, d => d.CityName);

            if (this.EstateTypes == null)
            {
                this.EstateTypes = new MultiSelectModel<EstateTypeModel, int>();
            }
            this.EstateTypes.Placeholder = Resources.MultiselectPlaceholder;
            this.EstateTypes.SetItems(await getAllEstateTypesTask, d => d.Name, d => d.Id);

            if (this.FurnishingType == null)
            {
                this.FurnishingType = new DropDownModel<FurnishingTypeModel, int?>();
            }
            this.FurnishingType.OptionLabel = Resources.SelectDropDownText;
            this.FurnishingType.SetItems(await getAllFurnishingTypesTask, c => c.Name, c => c.Id);

            if (this.ConstructionStatus == null)
            {
                this.ConstructionStatus = new DropDownModel<ConstructionStatusModel, int?>();
            }
            this.ConstructionStatus.OptionLabel = Resources.SelectDropDownText;
            this.ConstructionStatus.SetItems(await getAllConstructionStatusesTask, c => c.Name, c => c.Id);

            if (this.ConstructionType == null)
            {
                this.ConstructionType = new DropDownModel<ConstructionTypeModel, int?>();
            }
            this.ConstructionType.OptionLabel = Resources.SelectDropDownText;
            this.ConstructionType.SetItems(await getAllConstructionTypesTask, c => c.Name, c => c.Id);

            if (this.HeatingInstallations == null)
            {
                this.HeatingInstallations = new MultiSelectModel<HeatingInstallationModel, int>();
            }
            this.HeatingInstallations.Placeholder = Resources.MultiselectPlaceholder;
            this.HeatingInstallations.SetItems(await getAllHeatingInstallationsTask, c => c.Name, c => c.Id);

            if (this.JoineryType == null)
            {
                this.JoineryType = new DropDownModel<JoineryTypeModel, int?>();
            }
            this.JoineryType.OptionLabel = Resources.SelectDropDownText;
            this.JoineryType.SetItems(await getAllJoineryTypesTask, c => c.Name, c => c.Id);

            if (this.FlooringType == null)
            {
                this.FlooringType = new DropDownModel<FlooringTypeModel, int?>();
            }
            this.FlooringType.OptionLabel = Resources.SelectDropDownText;
            this.FlooringType.SetItems(await getAllFlooringTypesTask, c => c.Name, c => c.Id);

            if (this.OfferStatus == null)
            {
                this.OfferStatus = new DropDownModel<OfferStatusModel, int?>();
            }
            this.OfferStatus.OptionLabel = Resources.SelectDropDownText;
            this.OfferStatus.SetItems(await getAllOfferStatusesTask, c => c.Name, c => c.Id);
        }
    }
}