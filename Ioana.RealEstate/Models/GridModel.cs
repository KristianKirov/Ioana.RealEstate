using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Ioana.RealEstate.Models
{
    public class GridModel<T>
    {
        public int VirtualItemsCount { get; private set; }

        public int CurrentPage { get; private set; }

        public int PageSize { get; private set; }

        public int PagesCount { get; private set; }

        public int DisplayingFrom { get; private set; }

        public int DisplayingTo { get; private set; }

        public T[] Items { get; private set; }

        public int[] Pages { get; private set; }

        public int PagerRadius { get; private set; }

        public string OrderBy { get; private set; }

        public bool OrderByAscending { get; private set; }

        public GridModel(T[] items, int totalItemsCount, GridModelData data)
        {
            this.PageSize = data.PageSize;
            this.CurrentPage = data.CurrentPage;
            this.OrderBy = data.OrderBy;
            this.OrderByAscending = data.OrderByAscending;

            this.Items = items;
            this.VirtualItemsCount = totalItemsCount;

            this.PagesCount = (this.VirtualItemsCount + this.PageSize - 1) / this.PageSize;
            if (this.CurrentPage > this.PagesCount || this.CurrentPage < 1)
            {
                this.CurrentPage = 1;
            }

            this.DisplayingFrom = ((this.CurrentPage - 1) * this.PageSize) + 1;
            this.DisplayingTo = Math.Min(this.CurrentPage * this.PageSize, this.VirtualItemsCount);

            this.FillPages();
        }

        private void FillPages()
        {
            if (this.PagesCount == 0)
            {
                this.Pages = new int[0];

                return;
            }

            this.PagerRadius = 2;

            List<int> pages = new List<int>();

            if (this.CurrentPage > 1)
            {
                pages.Add(this.CurrentPage - 1);
            }

            pages.Add(1);

            int leftStart = Math.Max(2, this.CurrentPage - (this.PagerRadius + 1));
            for (int i = leftStart; i < this.CurrentPage; i++)
            {
                pages.Add(i);
            }

            pages.Add(this.CurrentPage);

            int rightEnd = Math.Min(this.PagesCount - 1, this.CurrentPage + this.PagerRadius + 1);
            for (int i = this.CurrentPage + 1; i <= rightEnd; i++)
            {
                pages.Add(i);
            }

            pages.Add(this.PagesCount);

            if (this.CurrentPage < this.PagesCount)
            {
                pages.Add(this.CurrentPage + 1);
            }

            this.Pages = pages.ToArray();
        }

        public bool IsOrderedBy(string uniqueColumnName)
        {
            return this.OrderBy.Equals(uniqueColumnName, StringComparison.InvariantCultureIgnoreCase);
        }

        public bool IsOrderedAscendingBy(string uniqueColumnName)
        {
            if (this.IsOrderedBy(uniqueColumnName))
            {
                return this.OrderByAscending;
            }

            return false;
        }
    }
}
