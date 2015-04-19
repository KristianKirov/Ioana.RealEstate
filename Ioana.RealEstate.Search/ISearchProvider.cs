using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ioana.RealEstate.Search
{
    public interface ISearchProvider<TDocumentModel, TSearchModel>
    {
        string IndexName { get; }

        Task EnsureIndex();

        Task<SearchResult<TDocumentModel>> Find(TSearchModel searchCriteria, int skip, int take, string orderBy, bool accending);

        Task Index(TDocumentModel document);
    }
}
