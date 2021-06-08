﻿using Brdy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brdy.Data
{
    public class BirdList
    {
        public int BirdsId { get; set; }
        public string CommonName { get; set; }
        public string ScientificName { get; set; }
        public bool Observed { get; set; }
        public bool WantToSee { get; set; }

        public List<Location> Birds { get; set; }
        public List<Weather> Weather { get; set; }

    }
}
