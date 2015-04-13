using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ioana.RealEstate.Models
{
    public class ClientModel
    {
        public int Id { get; set; }

        public string Names { get; set; }

        public string Email { get; set; }

        public string[] Phones { get; set; }
    }
}