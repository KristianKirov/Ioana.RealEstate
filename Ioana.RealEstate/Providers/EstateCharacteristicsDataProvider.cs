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
    public class EstateCharacteristicsDataProvider : EntityFrameworkProvider<EstateCharacteristicsModel, EstateCharacteristic>
    {
        protected override EstateCharacteristicsModel BuildModel(EstateCharacteristic entity)
        {
            return new EstateCharacteristicsModel()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        protected override IQueryable<EstateCharacteristic> GetQuery(RealEstateDbContext dbContext)
        {
            return dbContext.EstateCharacteristics;
        }
    }
}