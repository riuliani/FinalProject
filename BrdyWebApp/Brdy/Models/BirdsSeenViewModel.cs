using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brdy.Models
{
    public class BirdsSeenViewModel
    {
        public string CommonName { get; set; }
        public string ScientificName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime DateTime { get; set; }
        public double Temperature { get; set; }
        public string Forecast { get; set; }

    }
}
