using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioana.RealEstate.Search
{
    public class SearchResult<TDocumentModel>
    {
        public TDocumentModel[] Items { get; private set; }

        public int TotalItems { get; private set; }

        public SearchResult(TDocumentModel[] items, int totalItems)
        {
            this.Items = items;
            this.TotalItems = totalItems;
        }
    }
}
