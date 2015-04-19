using Ioana.RealEstate.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ioana.RealEstate.Models
{
    public class EstateListModel : IRealEstateModel
    {
        public string Title { get; set; }

        public RealEstateSearchModel EstateSearch { get; set; }

        public GridModel<OfferIndexDocument> GridModel { get; set; }
    }
}