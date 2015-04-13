using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioana.RealEstate.Data.Model
{
    public class CallHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Index(IsUnique=false, IsClustered=true)]
        public int OfferId { get; set; }

        public virtual EstateOffer Offer { get; set; }

        public string Comment { get; set; }

        [Required]
        public int CallerId { get; set; }

        public virtual RealEstateUser Caller { get; set; }

        public DateTime CallTime { get; set; }
    }
}
