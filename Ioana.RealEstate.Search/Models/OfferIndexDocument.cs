using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioana.RealEstate.Search.Models
{
    public class OfferIndexDocument
    {
        public int Id { get; set; }

        public string OfferType { get; set; }

        public string City { get; set; }

        public string CityRegion  { get; set; }

        public decimal Price { get; set; }

        public string EstateType { get; set; }

        public string FurnishingType { get; set; }

        public string ConstructionStatus { get; set; }

        public string ConstructionType { get; set; }

        public int? YearOfConstruction { get; set; }

        public int Floor { get; set; }

        public bool HasElevator { get; set; }

        public string[] HeatingInstallations { get; set; }

        public bool HasParkingSpot { get; set; }

        public bool HasGarage { get; set; }

        public bool HasParkingLot { get; set; }

        public string JoineryType { get; set; }

        public string FlooringType { get; set; }

        public double Area { get; set; }

        public string Status { get; set; }

        public string[] PhoneNumbers { get; set; }

        public DateTime DateCreated { get; set; }

        public string Responsible { get; set; }
    }
}
