using Ioana.RealEstate.Models.Editors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ioana.RealEstate.Models
{
    public class CalledEstateModel
    {
        [Required]
        public bool AlreadyCalled { get; set; }

        public string Comment { get; set; }

        public DropDownModel<UserModel, int?> Caller { get; set; }
    }
}