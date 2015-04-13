using Ioana.RealEstate.Models.Nomenclatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Threading.Tasks;
using Ioana.RealEstate.Data.EntityFramework;

namespace Ioana.RealEstate.Providers
{
    public class OfferStatusesDataProvider : IDataProvider<OfferStatusModel>
    {
        public async Task<OfferStatusModel[]> GetAll()
        {
            OfferStatusModel[] allOfferStatuses;
            using (RealEstateDbContext dbContext = new RealEstateDbContext())
            {
                allOfferStatuses = await dbContext.OfferStatuses.Select(c => new OfferStatusModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToArrayAsync();
            }

            return allOfferStatuses;
        }
    }
}