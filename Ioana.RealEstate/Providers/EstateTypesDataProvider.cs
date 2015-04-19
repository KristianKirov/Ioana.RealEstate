using Ioana.RealEstate.Data.EntityFramework;
using Ioana.RealEstate.Models.Nomenclatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;
using Ioana.RealEstate.Data.Model;

namespace Ioana.RealEstate.Providers
{
    public class EstateTypesDataProvider : EntityFrameworkProvider<EstateTypeModel, EstateType>
    {
        protected override EstateTypeModel BuildModel(EstateType entity)
        {
            return new EstateTypeModel()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        protected override IQueryable<EstateType> GetQuery(RealEstateDbContext dbContext)
        {
            return dbContext.EstateTypes;
        }
    }
}