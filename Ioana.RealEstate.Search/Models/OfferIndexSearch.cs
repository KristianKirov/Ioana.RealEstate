using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioana.RealEstate.Search.Models
{
    public class OfferIndexSearch
    {
        public string OfferType { get; set; }

        public string City { get; set; }

        public string[] CityRegions { get; set; }

        public decimal? PriceFrom { get; set; }

        public decimal? PriceTo { get; set; }

        public string[] EstateTypes { get; set; }

        public string FurnishingType { get; set; }

        public string ConstructionStatus { get; set; }

        public string ConstructionType { get; set; }

        public int? YearOfConstruction { get; set; }

        public int? FloorFrom { get; set; }

        public int? FloorTo { get; set; }

        public bool? HasElevator { get; set; }

        public string[] HeatingInstallations { get; set; }

        public bool? HasParkingSpot { get; set; }

        public bool? HasGarage { get; set; }

        public bool? HasParkingLot { get; set; }

        public string JoineryType { get; set; }

        public string FlooringType { get; set; }

        public double? AreaFrom { get; set; }

        public double? AreaTo { get; set; }

        public string OfferStatus { get; set; }

        public string PhoneNumber { get; set; }

        public int? OfferId { get; set; }
    }
}
