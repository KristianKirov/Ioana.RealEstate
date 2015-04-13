using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ioana.RealEstate.Data.Model
{
    public class RealEstateUserPhone
    {
        [Required]
        [Index(IsUnique = false, IsClustered = true)]
        public int UserId { get; set; }

        public virtual RealEstateUser User { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [Index(IsUnique = true)]
        public string Phone { get; set; }
    }
}
