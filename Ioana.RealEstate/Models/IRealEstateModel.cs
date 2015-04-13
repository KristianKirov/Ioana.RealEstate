using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ioana.RealEstate.Models
{
    public interface IRealEstateModel
    {
        string Title { get; set; }

        RealEstateSearchModel EstateSearch { get; set; }
    }
}