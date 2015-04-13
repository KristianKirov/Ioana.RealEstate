using Ioana.RealEstate.Models.Nomenclatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using Ioana.RealEstate.Data.EntityFramework;

namespace Ioana.RealEstate.Providers
{
    public class CityRegionsDataProvider : IDataProvider<CityRegionModel>
    {
        public async Task<CityRegionModel[]> GetAll()
        {
            CityRegionModel[] allCityRegions;
            using (RealEstateDbContext dbContext = new RealEstateDbContext())
            {
                allCityRegions = await dbContext.CityRegions.Include(c => c.City)
                    .Select(cr => new CityRegionModel()
                    {
                        Id = cr.Id,
                        Name = cr.Name,
                        CityName = cr.City.Name
                    }).ToArrayAsync();
            }

            return allCityRegions;
        }
    }
}