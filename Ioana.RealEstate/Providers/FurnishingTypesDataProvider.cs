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
    public class FurnishingTypesDataProvider : EntityFrameworkProvider<FurnishingTypeModel, FurnishingType>
    {
        protected override FurnishingTypeModel BuildModel(FurnishingType entity)
        {
            return new FurnishingTypeModel()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        protected override IQueryable<FurnishingType> GetQuery(RealEstateDbContext dbContext)
        {
            return dbContext.FurnishingTypes;
        }
    }
}