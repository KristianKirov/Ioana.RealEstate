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
    public class FurnishingTypesDataProvider : IDataProvider<FurnishingTypeModel>
    {
        public async Task<FurnishingTypeModel[]> GetAll()
        {
            FurnishingTypeModel[] allFurnishingTypes;
            using (RealEstateDbContext dbContext = new RealEstateDbContext())
            {
                allFurnishingTypes = await dbContext.FurnishingTypes.Select(c => new FurnishingTypeModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToArrayAsync();
            }

            return allFurnishingTypes;
        }
    }
}