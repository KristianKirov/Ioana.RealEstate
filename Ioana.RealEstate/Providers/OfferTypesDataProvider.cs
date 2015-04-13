using Ioana.RealEstate.Data.EntityFramework;
using Ioana.RealEstate.Models.Nomenclatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Ioana.RealEstate.Providers
{
    public class OfferTypesDataProvider : IDataProvider<OfferTypeModel>
    {
        public async Task<OfferTypeModel[]> GetAll()
        {
            OfferTypeModel[] allOfferTypes;
            using (RealEstateDbContext dbContext = new RealEstateDbContext())
            {
                allOfferTypes = await dbContext.OfferTypes.Select(ot => new OfferTypeModel()
                {
                    Id = ot.Id,
                    Name = ot.Name
                }).ToArrayAsync();
            }

            return allOfferTypes;
        }
    }
}