using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Brdy.Models
{
    public class BirdsSeenViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Common Name")]
        public string CommonName { get; set; }
        [Display(Name = "Scientific Name")]
        public string ScientificName { get; set; }
        [Display(Name = "Latitude")]
        public double Latitude { get; set; }
        [Display(Name = "Longitude")]
        public double Longitude { get; set; }
        [Display(Name = "Date")]
        public DateTime DateTime { get; set; }
        [Display(Name = "Temperature")]
        public double Temperature { get; set; }
        [Display(Name = "Forecast")]
        public string Forecast { get; set; }
    }
}
