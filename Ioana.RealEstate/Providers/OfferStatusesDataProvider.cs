using Ioana.RealEstate.Models.Nomenclatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Threading.Tasks;
using Ioana.RealEstate.Data.EntityFramework;
using Ioana.RealEstate.Data.Model;

namespace Ioana.RealEstate.Providers
{
    public class OfferStatusesDataProvider : EntityFrameworkProvider<OfferStatusModel, OfferStatus>
    {
        protected override OfferStatusModel BuildModel(OfferStatus entity)
        {
            return new OfferStatusModel()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        protected override IQueryable<OfferStatus> GetQuery(RealEstateDbContext dbContext)
        {
            return dbContext.OfferStatuses;
        }
    }
}