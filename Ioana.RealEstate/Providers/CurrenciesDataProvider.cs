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
    public class CurrenciesDataProvider : EntityFrameworkProvider<CurrencyModel, Currency>
    {
        protected override CurrencyModel BuildModel(Currency entity)
        {
            return new CurrencyModel()
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }

        protected override IQueryable<Currency> GetQuery(RealEstateDbContext dbContext)
        {
            return dbContext.Currencies;
        }
    }
}