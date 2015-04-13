using Ioana.RealEstate.Data.Model;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioana.RealEstate.Data.EntityFramework
{
    public class RealEstateDbContext : IdentityDbContext<RealEstateUser, RealEstateRole, int, RealEstateUserLogin, RealEstateUserRole, RealEstateUserClaim>
    {
        public RealEstateDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<OfferType> OfferTypes { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<CityRegion> CityRegions { get; set; }

        public DbSet<EstateType> EstateTypes { get; set; }

        public DbSet<FurnishingType> FurnishingTypes { get; set; }

        public DbSet<ConstructionStatus> ConstructionStatuses { get; set; }

        public DbSet<ConstructionType> ConstructionTypes { get; set; }

        public DbSet<HeatingInstallation> HeatingInstallations { get; set; }

        public DbSet<JoineryType> JoineryTypes { get; set; }

        public DbSet<FlooringType> FlooringTypes { get; set; }

        public DbSet<OfferStatus> OfferStatuses { get; set; }

        public DbSet<EstateCharacteristic> EstateCharacteristics { get; set; }

        public DbSet<Currency> Currencies { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<ClientPhone> ClientPhones { get; set; }

        public DbSet<EstateOffer> Offers { get; set; }

        public DbSet<Document> Documents { get; set; }
    }
}
