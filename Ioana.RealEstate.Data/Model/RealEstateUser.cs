using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioana.RealEstate.Data.Model
{
    public class RealEstateUser : IdentityUser<int, RealEstateUserLogin, RealEstateUserRole, RealEstateUserClaim>
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public virtual ICollection<RealEstateUserPhone> Phones { get; set; }

        [InverseProperty("Responsible")]
        public virtual ICollection<EstateOffer> ResponsibleFor { get; set; }

        [InverseProperty("LastModifiedBy")]
        public virtual ICollection<EstateOffer> LastModifications { get; set; }
    }
}
