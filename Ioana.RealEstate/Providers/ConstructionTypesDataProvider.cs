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
    public class ConstructionTypesDataProvider : IDataProvider<ConstructionTypeModel>
    {
        public async Task<ConstructionTypeModel[]> GetAll()
        {
            ConstructionTypeModel[] allConstructionTypes;
            using (RealEstateDbContext dbContext = new RealEstateDbContext())
            {
                allConstructionTypes = await dbContext.ConstructionTypes.Select(c => new ConstructionTypeModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToArrayAsync();
            }

            return allConstructionTypes;
        }
    }
}