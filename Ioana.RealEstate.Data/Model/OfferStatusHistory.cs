using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioana.RealEstate.Data.Model
{
    public class OfferStatusHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int OfferId { get; set; }

        public virtual EstateOffer Offer { get; set; }

        [Required]
        public int NewStatusId { get; set; }

        public virtual OfferStatus NewStatus { get; set; }

        [Required]
        public int OldStatusId { get; set; }

        public virtual OfferStatus OldStatus { get; set; }

        public string Comment { get; set; }

        [Required]
        public DateTime ChangeTime { get; set; }
    }
}
