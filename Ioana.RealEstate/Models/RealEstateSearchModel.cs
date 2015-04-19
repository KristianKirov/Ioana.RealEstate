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
        public DropDownModel<OfferTypeModel, string> OfferType { get; set; }

        public DropDownModel<CityModel, string> City { get; set; }

        public MultiSelectModel<CityRegionModel, string> CityRegions { get; set; }

        [Range(0, int.MaxValue)]
        public decimal? PriceFrom { get; set; }

        [Range(0, int.MaxValue)]
        public decimal? PriceTo { get; set; }

        public MultiSelectModel<EstateTypeModel, string> EstateTypes { get; set; }

        public DropDownModel<FurnishingTypeModel, string> FurnishingType { get; set; }

        public DropDownModel<ConstructionStatusModel, string> ConstructionStatus { get; set; }

        public DropDownModel<ConstructionTypeModel, string> ConstructionType { get; set; }

        public int? YearOfConstruction { get; set; }

        public int? FloorFrom { get; set; }

        public int? FloorTo { get; set; }

        public bool? HasElevator { get; set; }

        public MultiSelectModel<HeatingInstallationModel, string> HeatingInstallations { get; set; }

        public bool? HasParkingSpot { get; set; }

        public bool? HasGarage { get; set; }

        public bool? HasParkingLot { get; set; }

        public DropDownModel<JoineryTypeModel, string> JoineryType { get; set; }

        public DropDownModel<FlooringTypeModel, string> FlooringType { get; set; }

        [Range(0, int.MaxValue)]
        public double? AreaFrom { get; set; }

        [Range(0, int.MaxValue)]
        public double? AreaTo { get; set; }

        public DropDownModel<OfferStatusModel, string> OfferStatus { get; set; }

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
                this.OfferType = new DropDownModel<OfferTypeModel, string>();
            }
            this.OfferType.OptionLabel = Resources.SelectDropDownText;
            this.OfferType.SetItems(await getAllOfferTypesTask, ot => ot.Name, ot => ot.Name);

            if (this.City == null)
            {
                this.City = new DropDownModel<CityModel, string>();
            }
            this.City.OptionLabel = Resources.SelectDropDownText;
            this.City.SetItems(await getAllCitiesTask, c => c.Name, c => c.Name);

            if (this.CityRegions == null)
            {
                this.CityRegions = new MultiSelectModel<CityRegionModel, string>();
            }
            this.CityRegions.Placeholder = Resources.MultiselectPlaceholder;
            this.CityRegions.SetItems(await getAllCityRegionsTask, d => d.Name, d => d.Name, d => d.CityName);

            if (this.EstateTypes == null)
            {
                this.EstateTypes = new MultiSelectModel<EstateTypeModel, string>();
            }
            this.EstateTypes.Placeholder = Resources.MultiselectPlaceholder;
            this.EstateTypes.SetItems(await getAllEstateTypesTask, d => d.Name, d => d.Name);

            if (this.FurnishingType == null)
            {
                this.FurnishingType = new DropDownModel<FurnishingTypeModel, string>();
            }
            this.FurnishingType.OptionLabel = Resources.SelectDropDownText;
            this.FurnishingType.SetItems(await getAllFurnishingTypesTask, c => c.Name, c => c.Name);

            if (this.ConstructionStatus == null)
            {
                this.ConstructionStatus = new DropDownModel<ConstructionStatusModel, string>();
            }
            this.ConstructionStatus.OptionLabel = Resources.SelectDropDownText;
            this.ConstructionStatus.SetItems(await getAllConstructionStatusesTask, c => c.Name, c => c.Name);

            if (this.ConstructionType == null)
            {
                this.ConstructionType = new DropDownModel<ConstructionTypeModel, string>();
            }
            this.ConstructionType.OptionLabel = Resources.SelectDropDownText;
            this.ConstructionType.SetItems(await getAllConstructionTypesTask, c => c.Name, c => c.Name);

            if (this.HeatingInstallations == null)
            {
                this.HeatingInstallations = new MultiSelectModel<HeatingInstallationModel, string>();
            }
            this.HeatingInstallations.Placeholder = Resources.MultiselectPlaceholder;
            this.HeatingInstallations.SetItems(await getAllHeatingInstallationsTask, c => c.Name, c => c.Name);

            if (this.JoineryType == null)
            {
                this.JoineryType = new DropDownModel<JoineryTypeModel, string>();
            }
            this.JoineryType.OptionLabel = Resources.SelectDropDownText;
            this.JoineryType.SetItems(await getAllJoineryTypesTask, c => c.Name, c => c.Name);

            if (this.FlooringType == null)
            {
                this.FlooringType = new DropDownModel<FlooringTypeModel, string>();
            }
            this.FlooringType.OptionLabel = Resources.SelectDropDownText;
            this.FlooringType.SetItems(await getAllFlooringTypesTask, c => c.Name, c => c.Name);

            if (this.OfferStatus == null)
            {
                this.OfferStatus = new DropDownModel<OfferStatusModel, string>();
            }
            this.OfferStatus.OptionLabel = Resources.SelectDropDownText;
            this.OfferStatus.SetItems(await getAllOfferStatusesTask, c => c.Name, c => c.Name);
        }
    }
}