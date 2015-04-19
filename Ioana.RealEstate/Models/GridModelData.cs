using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ioana.RealEstate.Models
{
    public class GridModelData
    {
        public int CurrentPage { get; private set; }

        public string OrderBy { get; private set; }

        public bool OrderByAscending { get; private set; }

        public int PageSize { get; private set; }

        delegate bool TryParse<T>(string input, out T value);

        public GridModelData(HttpRequestBase request, string defaultOrderBy, bool defaultOrderByAscending, int defaultPageSize)
        {
            this.CurrentPage = this.GetQueryValue(request, "page", 1, int.TryParse);
            this.OrderBy = this.GetQueryValue(request, "sort", defaultOrderBy, (string input, out string result) => { result = input; return true; });
            this.OrderByAscending = this.GetQueryValue(request, "sort-asc", defaultOrderByAscending, bool.TryParse);
            this.PageSize = this.GetQueryValue(request, "page-size", defaultPageSize, int.TryParse);
        }

        private T GetQueryValue<T>(HttpRequestBase request, string paramName, T defaultValue, TryParse<T> tryParse)
        {
            string currentPageString = request.QueryString[paramName];
            if (string.IsNullOrEmpty(currentPageString))
            {
                return defaultValue;
            }
            else
            {
                T currentValue;
                if (!tryParse(currentPageString, out currentValue))
                {
                    return defaultValue;
                }

                return currentValue;
            }
        }
    }
}