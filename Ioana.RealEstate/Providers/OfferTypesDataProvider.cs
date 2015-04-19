using Ioana.RealEstate.Data.EntityFramework;
using Ioana.RealEstate.Models.Nomenclatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;
using Ioana.RealEstate.Data.Model;

namespace Ioana.RealEstate.Providers
{
    public class OfferTypesDataProvider : EntityFrameworkProvider<OfferTypeModel, OfferType>
    {
        protected override OfferTypeModel BuildModel(OfferType entity)
        {
            return new OfferTypeModel()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        protected override IQueryable<OfferType> GetQuery(RealEstateDbContext dbContext)
        {
            return dbContext.OfferTypes;
        }
    }
}