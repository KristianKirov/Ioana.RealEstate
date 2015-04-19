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
    public class ConstructionTypesDataProvider : EntityFrameworkProvider<ConstructionTypeModel, ConstructionType>
    {
        protected override ConstructionTypeModel BuildModel(ConstructionType entity)
        {
            return new ConstructionTypeModel()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        protected override IQueryable<ConstructionType> GetQuery(RealEstateDbContext dbContext)
        {
            return dbContext.ConstructionTypes;
        }
    }
}