using Ioana.RealEstate.Configuration;
using Ioana.RealEstate.Converters;
using Ioana.RealEstate.Models.Editors;
using System;
using System.Collections.Specialized;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Ioana.RealEstate.Helpers
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString DropDownListFromModelFor<TModel, TKey>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TKey>> expression, DropDownModel<TKey> dropDownModel)
        {
            return htmlHelper.DropDownListFor(expression, dropDownModel.Items, dropDownModel.OptionLabel, new { @class = "form-control" });
        }

        public static MvcHtmlString MultiSelectFromModelFor<TModel, TKey>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TKey[]>> expression, MultiSelectModel<TKey> multiSelectModel)
        {
            return htmlHelper.ListBoxFor(expression, multiSelectModel.Items, new { @class = "form-control chosen", data_placeholder = multiSelectModel.Placeholder });
        }

        public static string GridUrl(this UrlHelper urlHelper, int? page = null, string orderby = null, bool? orderByAscending = null)
        {
            NameValueCollection queryString = urlHelper.RequestContext.HttpContext.Request.QueryString;

            RouteValueDictionary routeValues = new RouteValueDictionary();
            foreach (string queryParam in queryString.AllKeys)
	        {
                string queryParamValue = queryString[queryParam];

                //if (reverseSorting && queryParam.Equals("sort-asc", StringComparison.InvariantCultureIgnoreCase))
                //{
                //    bool sortAscending;
                //    if (!string.IsNullOrEmpty(queryParamValue) && bool.TryParse(queryParamValue, out sortAscending))
                //    {
                //        queryParamValue = (!sortAscending).ToString();
                //    }
                //}

                routeValues[queryParam] = queryParamValue;
	        }

            if (page != null)
            {
                routeValues["page"] = page.Value;
            }

            if (!string.IsNullOrEmpty(orderby))
            {
                routeValues["sort"] = orderby;
            }

            if (orderByAscending != null)
            {
                routeValues["sort-asc"] = orderByAscending.Value;
            }

            RouteValueDictionary routeDataValues = urlHelper.RequestContext.RouteData.Values;

            return urlHelper.Action(routeDataValues["action"].ToString(), routeDataValues["controller"].ToString(), routeValues);
        }

        public static string Price<TModel>(this HtmlHelper<TModel> htmlHelper, decimal price, int displayCurrencyId, bool convert = true)
        {
            CurrencyConverter currencyConverter = new CurrencyConverter();
            if (convert)
            {
                price = currencyConverter.FromDefaultCurrency(price, displayCurrencyId);
            }

            return string.Format("{0:N2} {1}", price, currencyConverter.GetDisplayName(displayCurrencyId));
        }

        public static string Date<TModel>(this HtmlHelper<TModel> htmlHelper, DateTime date)
        {
            date = TimeZoneInfo.ConvertTime(date, Settings.DisplayDateTimeZone);

            return date.ToString(Settings.DisplayDateFormat, Settings.DisplayCulture);
        }
    }
}