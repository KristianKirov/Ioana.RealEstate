using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioana.RealEstate.Data.Model
{
    public class ClientPhone
    {
        [Required]
        [Index(IsUnique=false, IsClustered=true)]
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Index(IsUnique=true)]
        public string Phone { get; set; }
    }
}
