using Ioana.RealEstate.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ioana.RealEstate.Models
{
    public class EstateOwnerModel
    {
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [PhoneNumbersRequired]
        public string[] PhoneNumbers { get; set; }

        public HashSet<string> ExistingPhones { get; private set; }

        public EstateOwnerModel()
        {
            this.ExistingPhones = new HashSet<string>();
        }
    }
}