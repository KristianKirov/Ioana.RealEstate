﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ioana.RealEstate.Models.Editors
{
    public class GeoPositionModel
    {
        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }
    }
}