using Ioana.RealEstate.Models.Nomenclatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ioana.RealEstate.Converters
{
    public class CurrencyConverter
    {
        private const int DEFAULT_CURRENCY_ID = 1;

        private const decimal EURO_TO_LEV_EXCHANGE_RATE = 1.9558m;

        public decimal ToDefaultCurrency(decimal currentValue, int currentCurrency)
        {
            if (currentCurrency == CurrencyConverter.DEFAULT_CURRENCY_ID)
            {
                return currentValue;
            }

            decimal exchangeRate = this.GetExchangeRate(currentCurrency, CurrencyConverter.DEFAULT_CURRENCY_ID);

            return currentValue * exchangeRate;
        }

        public decimal FromDefaultCurrency(decimal defaultValue, int toCurrency)
        {
            if (toCurrency == CurrencyConverter.DEFAULT_CURRENCY_ID)
            {
                return defaultValue;
            }

            decimal exchangeRate = this.GetExchangeRate(CurrencyConverter.DEFAULT_CURRENCY_ID, toCurrency);

            return defaultValue * exchangeRate;
        }

        private decimal GetExchangeRate(int fromCurrency, int toCurrency)
        {
            if (fromCurrency == 2 && toCurrency == 1)
            {
                return CurrencyConverter.EURO_TO_LEV_EXCHANGE_RATE;
            }
            else if (fromCurrency == 1 && toCurrency == 2)
            {
                return 1 / CurrencyConverter.EURO_TO_LEV_EXCHANGE_RATE;
            }

            throw new NotImplementedException();
        }

        public string GetDisplayName(int currencyId)
        {
            switch (currencyId)
            {
                case 1:
                    return "лв";
                case 2:
                    return "€";
                default:
                    throw new NotSupportedException(currencyId.ToString());
            }
        }
    }
}