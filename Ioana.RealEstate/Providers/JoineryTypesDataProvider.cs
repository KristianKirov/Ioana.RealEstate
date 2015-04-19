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
    public class JoineryTypesDataProvider : EntityFrameworkProvider<JoineryTypeModel, JoineryType>
    {
        protected override JoineryTypeModel BuildModel(JoineryType entity)
        {
            return new JoineryTypeModel()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        protected override IQueryable<JoineryType> GetQuery(RealEstateDbContext dbContext)
        {
            return dbContext.JoineryTypes;
        }
    }
}