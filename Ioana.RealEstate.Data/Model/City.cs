using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioana.RealEstate.Data.Model
{
    [Table("Cities", Schema = "nomenclatures")]
    public class City : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<CityRegion> Regions { get; set; }

        public virtual ICollection<EstateOffer> EstateOffers { get; set; }

        public City()
        {
            this.Regions = new HashSet<CityRegion>();
        }
    }
}
