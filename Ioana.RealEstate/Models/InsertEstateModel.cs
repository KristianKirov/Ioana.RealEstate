using Ioana.RealEstate.Localization;
using Ioana.RealEstate.Models.Editors;
using Ioana.RealEstate.Models.Nomenclatures;
using Ioana.RealEstate.Providers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using Ioana.RealEstate.Extensions.Authentication;
using Microsoft.AspNet.Identity;

namespace Ioana.RealEstate.Models
{
    public class InsertEstateModel
    {
        public int? Id { get; set; }

        [Required]
        public DropDownModel<OfferTypeModel, int> OfferType { get; set; }

        public bool? IsShortTermRent { get; set; }

        [Required]
        public DropDownModel<EstateTypeModel, int> EstateType { get; set; }

        [Required]
        public MultiSelectModelRequired<FurnishingTypeModel, int> FurnishingTypes { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public int? Floor { get; set; }

        public int? TotalFloors { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        public double? Area { get; set; }

        [Required]
        public DropDownModel<ConstructionStatusModel, int> ConstructionStatus { get; set; }

        [Required]
        public DropDownModel<ConstructionTypeModel, int> ConstructionType { get; set; }

        [Range(0, int.MaxValue)]
        public int? YearOfConstruction { get; set; }

        [Required]
        public MultiSelectModelRequired<HeatingInstallationModel, int> HeatingInstallations { get; set; }

        [Required]
        public bool HasElevator { get; set; }

        [Required]
        public DropDownModel<JoineryTypeModel, int> JoineryType { get; set; }

        public DropDownModel<FlooringTypeModel, int?> FlooringType { get; set; }

        [Required]
        public bool HasParkingSpot { get; set; }

        [Required]
        public bool HasGarage { get; set; }

        [Required]
        public bool HasParkingLot { get; set; }

        [Required]
        public MultiSelectModel<EstateCharacteristicsModel, int> EstateCharacteristics { get; set; }

        [Required]
        public string Description { get; set; }

        private FilesPickerModel images;
        public FilesPickerModel Images
        {
            get
            {
                return this.images;
            }
            set
            {
                this.images = value;

                if (this.images != null)
                {
                    this.images.Accept = "image/*";
                    this.images.PreviewImages = true;
                }
            }
        }

        [Required]
        [Range(0, int.MaxValue)]
        public decimal? Price { get; set; }

        [Required]
        public DropDownModel<CurrencyModel, int> Currency { get; set; }

        [Required]
        public bool HasCommision { get; set; }

        public string CommisionNotes { get; set; }

        [Required]
        public bool AcceptsPics { get; set; }

        [Required]
        public DropDownModel<CityModel, int> City { get; set; }

        [Required]
        public DropDownModel<CityRegionModel, int> CityRegion { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public GeoPositionModel Coordinates { get; set; }

        [Required]
        public EstateOwnerModel Owner { get; set; }

        [Required]
        public CalledEstateModel Called { get; set; }

        public DropDownModel<UserModel, int?> User { get; set; }

        public async Task Load(IPrincipal currentUser)
        {
            IDataProvider<OfferTypeModel> offerTypesProvider = new OfferTypesDataProvider();
            IDataProvider<EstateTypeModel> estateTypesProvider = new EstateTypesDataProvider();
            IDataProvider<FurnishingTypeModel> furnishingTypesProvider = new FurnishingTypesDataProvider();
            IDataProvider<ConstructionStatusModel> constructionStatusesProvider = new ConstructionStatusesDataProvider();
            IDataProvider<ConstructionTypeModel> constructionTypesProvider = new ConstructionTypesDataProvider();
            IDataProvider<HeatingInstallationModel> heatingInstallationsProvider = new HeatingInstallationsDataProvider();
            IDataProvider<FlooringTypeModel> flooringTypesProvider = new FlooringTypesDataProvider();
            IDataProvider<JoineryTypeModel> joineryTypesProvider = new JoineryTypesDataProvider();
            IDataProvider<EstateCharacteristicsModel> estateCharacteristicsProvider = new EstateCharacteristicsDataProvider();
            IDataProvider<CurrencyModel> currenciesProvider = new CurrenciesDataProvider();
            IDataProvider<CityModel> citiesProvider = new CitiesDataProvider();
            IDataProvider<CityRegionModel> cityRegionsProvider = new CityRegionsDataProvider();
            ClientDataProvider clientDataProvider = new ClientDataProvider();
            IDataProvider<UserModel> usersDataProvider = new UsersDataProvider();

            Task<OfferTypeModel[]> getAllOfferTypesTask = offerTypesProvider.GetAll();
            Task<EstateTypeModel[]> getAllEstateTypesTask = estateTypesProvider.GetAll();
            Task<FurnishingTypeModel[]> getAllFurnishingTypesTask = furnishingTypesProvider.GetAll();
            Task<ConstructionStatusModel[]> getAllConstructionStatusesTask = constructionStatusesProvider.GetAll();
            Task<ConstructionTypeModel[]> getAllConstructionTypesTask = constructionTypesProvider.GetAll();
            Task<HeatingInstallationModel[]> getAllHeatingInstallationsTask = heatingInstallationsProvider.GetAll();
            Task<JoineryTypeModel[]> getAllJoineryTypesTask = joineryTypesProvider.GetAll();
            Task<FlooringTypeModel[]> getAllFlooringTypesTask = flooringTypesProvider.GetAll();
            Task<EstateCharacteristicsModel[]> getAllEstateCharacteristicsTask = estateCharacteristicsProvider.GetAll();
            Task<CurrencyModel[]> getAllCurrenciesTask = currenciesProvider.GetAll();
            Task<CityModel[]> getAllCitiesTask = citiesProvider.GetAll();
            Task<CityRegionModel[]> getAllCityRegionsTask = cityRegionsProvider.GetAll();
            Task<string[]> getClientPhonesTask = null;
            if (this.Owner != null && this.Owner.Id != null && this.Owner.ExistingPhones.Count == 0)
            {
                getClientPhonesTask = clientDataProvider.GetClientPhones(this.Owner.Id.Value);
            }
            Task<UserModel[]> getAllUsersTask = null;
            if (currentUser.IsAdmin())
            {
                getAllUsersTask = usersDataProvider.GetAll();
            }
            
            if (this.OfferType == null)
            {
                this.OfferType = new DropDownModel<OfferTypeModel, int>();
            }
            this.OfferType.OptionLabel = Resources.SelectDropDownText;
            this.OfferType.SetItems(await getAllOfferTypesTask, ot => ot.Name, ot => ot.Id);

            if (this.EstateType == null)
            {
                this.EstateType = new DropDownModel<EstateTypeModel, int>();
            }
            this.EstateType.OptionLabel = Resources.SelectDropDownText;
            this.EstateType.SetItems(await getAllEstateTypesTask, ot => ot.Name, ot => ot.Id);

            if (this.FurnishingTypes == null)
            {
                this.FurnishingTypes = new MultiSelectModelRequired<FurnishingTypeModel, int>();
            }
            this.FurnishingTypes.Placeholder = Resources.MultiselectPlaceholder;
            this.FurnishingTypes.SetItems(await getAllFurnishingTypesTask, ot => ot.Name, ot => ot.Id);

            if (this.Images == null)
            {
                this.Images = new FilesPickerModel();
            }
            this.Images.SelectLabel = Resources.SelectImageLabel;

            if (this.ConstructionStatus == null)
            {
                this.ConstructionStatus = new DropDownModel<ConstructionStatusModel, int>();
            }
            this.ConstructionStatus.OptionLabel = Resources.SelectDropDownText;
            this.ConstructionStatus.SetItems(await getAllConstructionStatusesTask, ot => ot.Name, ot => ot.Id);

            if (this.ConstructionType == null)
            {
                this.ConstructionType = new DropDownModel<ConstructionTypeModel, int>();
            }
            this.ConstructionType.OptionLabel = Resources.SelectDropDownText;
            this.ConstructionType.SetItems(await getAllConstructionTypesTask, c => c.Name, c => c.Id);

            if (this.HeatingInstallations == null)
            {
                this.HeatingInstallations = new MultiSelectModelRequired<HeatingInstallationModel, int>();
            }
            this.HeatingInstallations.Placeholder = Resources.MultiselectPlaceholder;
            this.HeatingInstallations.SetItems(await getAllHeatingInstallationsTask, c => c.Name, c => c.Id);

            if (this.JoineryType == null)
            {
                this.JoineryType = new DropDownModel<JoineryTypeModel, int>();
            }
            this.JoineryType.OptionLabel = Resources.SelectDropDownText;
            this.JoineryType.SetItems(await getAllJoineryTypesTask, c => c.Name, c => c.Id);

            if (this.FlooringType == null)
            {
                this.FlooringType = new DropDownModel<FlooringTypeModel, int?>();
            }
            this.FlooringType.OptionLabel = Resources.SelectDropDownText;
            this.FlooringType.SetItems(await getAllFlooringTypesTask, c => c.Name, c => c.Id);

            if (this.EstateCharacteristics == null)
            {
                this.EstateCharacteristics = new MultiSelectModel<EstateCharacteristicsModel, int>();
            }
            this.EstateCharacteristics.Placeholder = Resources.MultiselectPlaceholder;
            this.EstateCharacteristics.SetItems(await getAllEstateCharacteristicsTask, c => c.Name, c => c.Id);

            if (this.Currency == null)
            {
                this.Currency = new DropDownModel<CurrencyModel, int>();
            }
            CurrencyModel[] allCurrencies = await getAllCurrenciesTask;
            this.Currency.SetItems(allCurrencies, ot => ot.Name, ot => ot.Id);
            if (this.Currency.Id == 0)
            {
                this.Currency.Id = allCurrencies[0].Id;
            }

            if (this.City == null)
            {
                this.City = new DropDownModel<CityModel, int>();
            }
            this.City.OptionLabel = Resources.SelectDropDownText;
            this.City.SetItems(await getAllCitiesTask, c => c.Name, c => c.Id);

            if (this.CityRegion == null)
            {
                this.CityRegion = new DropDownModel<CityRegionModel, int>();
            }
            this.CityRegion.OptionLabel = Resources.SelectDropDownText;
            this.CityRegion.SetItems(await getAllCityRegionsTask, d => d.Name, d => d.Id, d => d.CityName);

            if (getClientPhonesTask != null)
            {
                string[] ownerPhones = await getClientPhonesTask;
                foreach (string ownerPhone in ownerPhones)
                {
                    this.Owner.ExistingPhones.Add(ownerPhone);
                }
            }

            if (this.Called == null)
            {
                this.Called = new CalledEstateModel();
            }
            if (getAllUsersTask != null)
            {
                if (this.Called.Caller == null)
                {
                    this.Called.Caller = new DropDownModel<UserModel, int?>();
                }
                this.Called.Caller.SetItems(await getAllUsersTask, u => u.FullName, u => u.Id);
                if (this.Called.Caller.Id == null)
                {
                    this.Called.Caller.Id = currentUser.Identity.GetUserId<int>();
                }
            }

            if (getAllUsersTask != null)
            {
                if (this.User == null)
                {
                    this.User = new DropDownModel<UserModel, int?>();
                }
                this.User.OptionLabel = Resources.LeaveWithoutUserLabel;
                this.User.SetItems(await getAllUsersTask, u => u.FullName, u => u.Id);
                if (this.User.Id == null)
                {
                    this.User.Id = currentUser.Identity.GetUserId<int>();
                }
            }
        }
    }
}