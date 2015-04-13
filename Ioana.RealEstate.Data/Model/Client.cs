using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioana.RealEstate.Data.Model
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public virtual ICollection<ClientPhone> Phones { get; set; }

        [Required]
        public string Names { get; set; }

        [Required]
        public string Email { get; set; }

        public bool IsSeeking { get; set; }

        public bool IsOffering { get; set; }

        public DateTime DateCreated { get; set; }

        public virtual ICollection<EstateOffer> Offers { get; set; }
    }
}
