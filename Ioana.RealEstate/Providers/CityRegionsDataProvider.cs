using Ioana.RealEstate.Models.Nomenclatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using Ioana.RealEstate.Data.EntityFramework;
using Ioana.RealEstate.Data.Model;

namespace Ioana.RealEstate.Providers
{
    public class CityRegionsDataProvider : EntityFrameworkProvider<CityRegionModel, CityRegion>
    {
        protected override CityRegionModel BuildModel(CityRegion entity)
        {
            return new CityRegionModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                CityName = entity.City.Name
            };
        }

        protected override IQueryable<CityRegion> GetQuery(RealEstateDbContext dbContext)
        {
            return dbContext.CityRegions.Include(cr => cr.City);
        }
    }
}