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
    }
}