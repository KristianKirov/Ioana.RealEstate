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
    public class FlooringTypesDataProvider : IDataProvider<FlooringTypeModel>
    {
        public async Task<FlooringTypeModel[]> GetAll()
        {
            FlooringTypeModel[] allFlooringTypes;
            using (RealEstateDbContext dbContext = new RealEstateDbContext())
            {
                allFlooringTypes = await dbContext.FlooringTypes.Select(c => new FlooringTypeModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToArrayAsync();
            }

            return allFlooringTypes;
        }
    }
}