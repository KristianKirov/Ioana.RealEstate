using Ioana.RealEstate.Data.EntityFramework;
using Ioana.RealEstate.Models.Nomenclatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web;

namespace Ioana.RealEstate.Providers
{
    public class CitiesDataProvider : IDataProvider<CityModel>
    {
        public async Task<CityModel[]> GetAll()
        {
            CityModel[] allCities;
            using (RealEstateDbContext dbContext = new RealEstateDbContext())
            {
                allCities = await dbContext.Cities.Select(c => new CityModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToArrayAsync();
            }

            return allCities;
        }
    }
}