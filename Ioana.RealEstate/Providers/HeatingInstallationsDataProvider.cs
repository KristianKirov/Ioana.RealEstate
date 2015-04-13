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
    public class HeatingInstallationsDataProvider : IDataProvider<HeatingInstallationModel>
    {
        public async Task<HeatingInstallationModel[]> GetAll()
        {
            HeatingInstallationModel[] allHeatingInstallations;
            using (RealEstateDbContext dbContext = new RealEstateDbContext())
            {
                allHeatingInstallations = await dbContext.HeatingInstallations.Select(c => new HeatingInstallationModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToArrayAsync();
            }

            return allHeatingInstallations;
        }
    }
}