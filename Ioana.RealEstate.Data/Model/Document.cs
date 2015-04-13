using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioana.RealEstate.Data.Model
{
    public class Document
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string ContentType { get; set; }

        [Required]
        [Index(IsUnique=true)]
        [MaxLength(256)]
        public string Url { get; set; }

        public virtual ICollection<EstateOffer> EstateOffers { get; set; }
    }
}
