using Ioana.RealEstate.Models.Nomenclatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Threading.Tasks;
using Ioana.RealEstate.Data.EntityFramework;

namespace Ioana.RealEstate.Providers
{
    public class JoineryTypesDataProvider : IDataProvider<JoineryTypeModel>
    {
        public async Task<JoineryTypeModel[]> GetAll()
        {
            JoineryTypeModel[] allJoineryTypes;
            using (RealEstateDbContext dbContext = new RealEstateDbContext())
            {
                allJoineryTypes = await dbContext.JoineryTypes.Select(c => new JoineryTypeModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToArrayAsync();
            }

            return allJoineryTypes;
        }
    }
}