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
    public class EstateCharacteristicsDataProvider : IDataProvider<EstateCharacteristicsModel>
    {
        public async Task<EstateCharacteristicsModel[]> GetAll()
        {
            EstateCharacteristicsModel[] allEstateCharacteristics;
            using (RealEstateDbContext dbContext = new RealEstateDbContext())
            {
                allEstateCharacteristics = await dbContext.EstateCharacteristics.Select(ec => new EstateCharacteristicsModel()
                {
                    Id = ec.Id,
                    Name = ec.Name
                }).ToArrayAsync();
            }

            return allEstateCharacteristics;
        }
    }
}