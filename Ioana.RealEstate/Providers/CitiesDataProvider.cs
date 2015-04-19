using Ioana.RealEstate.Data.EntityFramework;
using Ioana.RealEstate.Models.Nomenclatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web;
using Ioana.RealEstate.Data.Model;

namespace Ioana.RealEstate.Providers
{
    public class CitiesDataProvider : EntityFrameworkProvider<CityModel, City>
    {
        protected override CityModel BuildModel(City entity)
        {
            return new CityModel()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        protected override IQueryable<City> GetQuery(RealEstateDbContext dbContext)
        {
            return dbContext.Cities;
        }
    }
}