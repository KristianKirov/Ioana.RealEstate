using Ioana.RealEstate.Data.EntityFramework;
using Ioana.RealEstate.Models.Nomenclatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Ioana.RealEstate.Providers
{
    public class EstateTypesDataProvider : IDataProvider<EstateTypeModel>
    {
        public async Task<EstateTypeModel[]> GetAll()
        {
            EstateTypeModel[] allEstateTypes;
            using (RealEstateDbContext dbContext = new RealEstateDbContext())
            {
                allEstateTypes = await dbContext.EstateTypes.Select(ot => new EstateTypeModel()
                {
                    Id = ot.Id,
                    Name = ot.Name
                }).ToArrayAsync();
            }

            return allEstateTypes;
        }
    }
}