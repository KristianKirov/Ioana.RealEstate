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

            return this.RedirectToAction("Details", "Estates", new { Id = estateModel.Id });
        }
    }
}