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
    public class ConstructionStatusesDataProvider : IDataProvider<ConstructionStatusModel>
    {
        public async Task<ConstructionStatusModel[]> GetAll()
        {
            ConstructionStatusModel[] allConstructionStatuses;
            using (RealEstateDbContext dbContext = new RealEstateDbContext())
            {
                allConstructionStatuses = await dbContext.ConstructionStatuses.Select(c => new ConstructionStatusModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToArrayAsync();
            }

            return allConstructionStatuses;
        }
    }
}