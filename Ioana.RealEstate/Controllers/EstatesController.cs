using Ioana.RealEstate.Localization;
using Ioana.RealEstate.Models;
using Ioana.RealEstate.Models.Editors;
using Ioana.RealEstate.Models.Nomenclatures;
using Ioana.RealEstate.Providers;
using Ioana.RealEstate.Storage;
using Ioana.RealEstate.Extensions.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.Web.Hosting;
using Ioana.RealEstate.Search.Models;
using Ioana.RealEstate.Factories;
using Ioana.RealEstate.DataManipulation;
using Ioana.RealEstate.Search;
using Ioana.RealEstate.Converters;

namespace Ioana.RealEstate.Controllers
{
    [Authorize]
    public class EstatesController : Controller
    {
        private readonly DocumentDataProvider documentDataProvider;

        private readonly ClientDataProvider clientDataProvider;

        private readonly EstatesOffersDataProvider offersDataProvider;

        public EstatesController()
        {
            IFileStorage fileStorage = new FileSystemStorage(HostingEnvironment.MapPath("\\docs"));
            this.documentDataProvider = new DocumentDataProvider(fileStorage);

            this.clientDataProvider = new ClientDataProvider();
            this.offersDataProvider = new EstatesOffersDataProvider();
        }

        public async Task<ActionResult> Index()
        {
            EstateListModel estateListModel = new EstateListModel();
            await estateListModel.EstateSearch.Load();

            return View(estateListModel);
        }

        [HttpGet]
        public async Task<ActionResult> Index(RealEstateSearchModel searchModel)
        {
            EstateListModel estateListModel = new EstateListModel();
            estateListModel.EstateSearch = searchModel;
            await estateListModel.EstateSearch.Load();

            if (!this.ModelState.IsValid)
            {
                return View(estateListModel);
            }

            PhoneNormalizer phoneNormalizer = new PhoneNormalizer();
            OfferIndexSearch searchCriteria = new OfferIndexSearch()
            {
                OfferType = searchModel.OfferType.Id,
                City = searchModel.City.Id,
                CityRegions = searchModel.CityRegions.SelectedIds,
                EstateTypes = searchModel.EstateTypes.SelectedIds,
                FurnishingType = searchModel.FurnishingType.Id,
                ConstructionStatus = searchModel.ConstructionStatus.Id,
                ConstructionType = searchModel.ConstructionType.Id,
                YearOfConstruction = searchModel.YearOfConstruction,
                FloorFrom = searchModel.FloorFrom,
                FloorTo = searchModel.FloorTo,
                HasElevator = searchModel.HasElevator,
                HeatingInstallations = searchModel.HeatingInstallations.SelectedIds,
                HasParkingSpot = searchModel.HasParkingSpot,
                HasGarage = searchModel.HasGarage,
                HasParkingLot = searchModel.HasParkingLot,
                JoineryType = searchModel.JoineryType.Id,
                FlooringType = searchModel.FlooringType.Id,
                AreaFrom = searchModel.AreaFrom,
                AreaTo = searchModel.AreaTo,
                OfferStatus = searchModel.OfferStatus.Id,
                PhoneNumber = phoneNormalizer.Normalize(searchModel.PhoneNumber),
                OfferId = searchModel.OfferId
            };

            CurrencyConverter currencyConverter = new CurrencyConverter();
            if (searchModel.PriceFrom != null)
            {
                searchCriteria.PriceFrom = currencyConverter.ToDefaultCurrency(searchModel.PriceFrom.Value, searchModel.Currency.Id);
            }

            if (searchModel.PriceTo != null)
            {
                searchCriteria.PriceTo = currencyConverter.ToDefaultCurrency(searchModel.PriceTo.Value, searchModel.Currency.Id);
            }

            GridModelData gridData = new GridModelData(this.Request, "dateCreated", false, 10);
            SearchResult<OfferIndexDocument> documentsResult = await SearchProviders.EstateOffer.Find(
                searchCriteria, (gridData.CurrentPage - 1) * gridData.PageSize, gridData.PageSize, gridData.OrderBy, gridData.OrderByAscending);
            
            estateListModel.GridModel = new GridModel<OfferIndexDocument>(documentsResult.Items, documentsResult.TotalItems, gridData);

            return View(estateListModel);
        }

        public async Task<ActionResult> Upsert()
        {
            GenericRealEstateModel<InsertEstateModel> genericModel = new GenericRealEstateModel<InsertEstateModel>();

            genericModel.EstateSearch = new RealEstateSearchModel();
            await genericModel.EstateSearch.Load();

            genericModel.Data = new InsertEstateModel();
            await genericModel.Data.Load(this.User);

            return View(genericModel);
        }

        [HttpPost]
        public async Task<ActionResult> Upsert(InsertEstateModel estateModel)
        {
            if (!this.ModelState.IsValid)
            {
                GenericRealEstateModel<InsertEstateModel> genericModel = new GenericRealEstateModel<InsertEstateModel>();

                genericModel.EstateSearch = new RealEstateSearchModel();
                await genericModel.EstateSearch.Load();

                genericModel.Data = estateModel;
                await genericModel.Data.Load(this.User);

                return View(genericModel);
            }

            if (estateModel.Id == null)
            {
                int currentUserId = this.User.Identity.GetUserId<int>();

                if (!this.User.IsAdmin())
                {
                    estateModel.User = new DropDownModel<UserModel, int?>();
                    estateModel.User.Id = currentUserId;
                }

                if (estateModel.Called.AlreadyCalled)
                {
                    if (estateModel.Called.Caller == null)
                    {
                        estateModel.Called.Caller = new DropDownModel<UserModel, int?>();
                    }

                    if (estateModel.Called.Caller.Id == null || !this.User.IsAdmin())
                    {
                        estateModel.Called.Caller.Id = currentUserId;
                    }
                }

                if (estateModel.Images != null)
                {
                    HttpPostedFileBase[] uploadedImages = estateModel.Images.GetApplicableFiles();
                    if (uploadedImages.Length > 0)
                    {
                        InsertDocumentModel[] imagesToInsert = uploadedImages.Select(f => new InsertDocumentModel()
                        {
                            Url = f.FileName,
                            ContentType = f.ContentType,
                            FileStream = f.InputStream
                        }).ToArray();

                        await this.documentDataProvider.Save(imagesToInsert);

                        estateModel.Images.ExistingImages = imagesToInsert;
                    }
                }

                if (estateModel.Owner.Id == null)
                {
                    ClientModel clientToInsert = new ClientModel()
                    {
                        Names = estateModel.Owner.Name,
                        Email = estateModel.Owner.Email,
                        Phones = estateModel.Owner.PhoneNumbers
                    };

                    await this.clientDataProvider.InsertOfferingClient(clientToInsert);

                    estateModel.Owner.Id = clientToInsert.Id;
                }
                else
                {
                    ClientModel clientToUpdate = new ClientModel()
                    {
                        Id = estateModel.Owner.Id.Value,
                        Names = estateModel.Owner.Name,
                        Email = estateModel.Owner.Email,
                        Phones = estateModel.Owner.PhoneNumbers
                    };

                    await this.clientDataProvider.UpdateOfferingClient(clientToUpdate);
                }

                await this.offersDataProvider.AddNewEstate(estateModel, currentUserId);
            }

            OfferIndexDocumentFactory offerIndexDocumentFactory = new OfferIndexDocumentFactory();
            OfferIndexDocument offerIndexDocument = await offerIndexDocumentFactory.CreateFromInsertModel(estateModel);

            await SearchProviders.EstateOffer.Index(offerIndexDocument);

            ThumbnailProvider thumbnailProvider = new ThumbnailProvider();
            await thumbnailProvider.GenerateDefaultThumbnail(estateModel.Id.Value);

            return this.RedirectToAction("Details", "Estates", new { Id = estateModel.Id.Value });
        }

        public async Task<ActionResult> ReindexDocuments()
        {
            await SearchProviders.EstateOffer.Index(new OfferIndexDocument()
            {
                Id = 5,
                DisplayCurrencyId = 1
            });

            await SearchProviders.EstateOffer.Index(new OfferIndexDocument()
            {
                Id = 6,
                DisplayCurrencyId = 2
            });

            await SearchProviders.EstateOffer.Index(new OfferIndexDocument()
            {
                Id = 7,
                DisplayCurrencyId = 1
            });

            return this.RedirectToAction("Index");
        }
    }
}