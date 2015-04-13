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
    public class CurrenciesDataProvider : IDataProvider<CurrencyModel>
    {
        public async Task<CurrencyModel[]> GetAll()
        {
            CurrencyModel[] allCurrencies;
            using (RealEstateDbContext dbContext = new RealEstateDbContext())
            {
                allCurrencies = await dbContext.Currencies.Select(c => new CurrencyModel()
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToArrayAsync();
            }

            return allCurrencies;
        }
    }
}