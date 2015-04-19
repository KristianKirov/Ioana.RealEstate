using Ioana.RealEstate.Search;
using Ioana.RealEstate.Search.ElasticSearch;
using Ioana.RealEstate.Search.Models;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Ioana.RealEstate.Providers
{
    public static class SearchProviders
    {
        public static ISearchProvider<OfferIndexDocument, OfferIndexSearch> EstateOffer { get; private set; }

        static SearchProviders()
        {
            Uri node = new Uri("https://92w9msf14w:buxd4jnq8e@express-real-estate-438942257.eu-west-1.bonsai.io");
            ConnectionSettings elasticSettings = new ConnectionSettings(node);
            IElasticClient elasticClient = new ElasticClient(elasticSettings);

            SearchProviders.EstateOffer = new EstateOfferSearchProvider(elasticClient);
        }

        public static async Task EnsureIndices()
        {
            await SearchProviders.EstateOffer.EnsureIndex();
        }
    }
}