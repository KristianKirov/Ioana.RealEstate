using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioana.RealEstate.Data.Model
{
    public class EstateOffer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int OfferTypeId { get; set; }

        public virtual OfferType OfferType { get; set; }

        public bool? IsShortTermRent { get; set; }

        [Required]
        public int EstateTypeId { get; set; }

        public virtual EstateType EstateType { get; set; }

        [Required]
        public virtual ICollection<FurnishingType> FurnishingTypes { get; set; }

        [Required]
        public int Floor { get; set; }

        public int? TotalFloors { get; set; }

        [Required]
        public double Area { get; set; }

        [Required]
        public int ConstructionStatusId { get; set; }

        public virtual ConstructionStatus ConstructionStatus { get; set; }

        [Required]
        public int ConstructionTypeId { get; set; }

        public virtual ConstructionType ConstructionType { get; set; }

        public int? YearOfConstruction { get; set; }

        [Required]
        public virtual ICollection<HeatingInstallation> HeatingInstallations { get; set; }

        [Required]
        public bool HasElevator { get; set; }

        [Required]
        public int JoineryTypeId { get; set; }

        public virtual JoineryType JoineryType { get; set; }

        public int? FlooringTypeId { get; set; }

        public virtual FlooringType FlooringType { get; set; }

        [Required]
        public bool HasParkingSpot { get; set; }

        [Required]
        public bool HasGarage { get; set; }

        [Required]
        public bool HasParkingLot { get; set; }

        [Required]
        public virtual ICollection<EstateCharacteristic> EstateCharacteristics { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<Document> Images { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int CurrencyId { get; set; }

        public virtual Currency Currency { get; set; }

        [Required]
        public bool HasCommision { get; set; }

        public string CommisionNotes { get; set; }

        [Required]
        public bool AcceptsPics { get; set; }

        [Required]
        public int CityId { get; set; }

        public virtual City City { get; set; }

        [Required]
        public int CityRegionId { get; set; }

        public virtual CityRegion CityRegion { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

        [Required]
        public int OwnerId { get; set; }

        public virtual Client Owner { get; set; }

        [Required]
        public bool Called { get; set; }

        public virtual ICollection<CallHistory> Calls { get; set; }

        public int? ResponsibleId { get; set; }

        public virtual RealEstateUser Responsible { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public int LastModifiedById { get; set; }

        public virtual RealEstateUser LastModifiedBy { get; set; }

        [Required]
        public DateTime LastModifiedDate { get; set; }

        [Required]
        public int StatusId { get; set; }

        public virtual OfferStatus Status { get; set; }

        public virtual ICollection<OfferStatusHistory> StatusHistory { get; set; }
    }
}
