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
    public class HeatingInstallationsDataProvider : EntityFrameworkProvider<HeatingInstallationModel, HeatingInstallation>
    {
        protected override HeatingInstallationModel BuildModel(HeatingInstallation entity)
        {
            return new HeatingInstallationModel()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        protected override IQueryable<HeatingInstallation> GetQuery(RealEstateDbContext dbContext)
        {
            return dbContext.HeatingInstallations;
        }
    }
}