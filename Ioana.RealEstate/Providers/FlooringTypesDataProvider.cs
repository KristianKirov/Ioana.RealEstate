using Ioana.RealEstate.Models.Nomenclatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Threading.Tasks;
using Ioana.RealEstate.Data.EntityFramework;
using Ioana.RealEstate.Data.Model;

namespace Ioana.RealEstate.Providers
{
    public class FlooringTypesDataProvider : EntityFrameworkProvider<FlooringTypeModel, FlooringType>
    {
        protected override FlooringTypeModel BuildModel(FlooringType entity)
        {
            return new FlooringTypeModel()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        protected override IQueryable<FlooringType> GetQuery(RealEstateDbContext dbContext)
        {
            return dbContext.FlooringTypes;
        }
    }
}