using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ioana.RealEstate.Models.Api
{
    public class ValidatePhoneRequest
    {
        public bool IncludeClientData { get; set; }

        [Required]
        [StringLength(20)]
        public string Phone { get; set; }
    }
}