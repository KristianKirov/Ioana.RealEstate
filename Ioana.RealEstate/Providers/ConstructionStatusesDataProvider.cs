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
    public class ConstructionStatusesDataProvider : EntityFrameworkProvider<ConstructionStatusModel, ConstructionStatus>
    {
        protected override ConstructionStatusModel BuildModel(ConstructionStatus entity)
        {
            return new ConstructionStatusModel()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        protected override IQueryable<ConstructionStatus> GetQuery(RealEstateDbContext dbContext)
        {
            return dbContext.ConstructionStatuses;
        }
    }
}