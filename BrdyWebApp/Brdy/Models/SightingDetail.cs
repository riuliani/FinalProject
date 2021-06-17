using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Brdy.Models
{
    public class SightingDetail
    {
        public string speciesCode { get; set; }
        [Display(Name = "Common Name")]
        public string comName { get; set; }
        [Display(Name = "Scientific Name")]
        public string sciName { get; set; }
        [Display(Name = "")]
        public string locId { get; set; }
        [Display(Name = "Location")]
        public string locName { get; set; }
        [Display(Name = "Observed")]
        public string obsDt { get; set; }
        [Display(Name = "Time")]
        public int howMany { get; set; }
        [Display(Name = "Spotted")]
        public double lat { get; set; }
        [Display(Name = "Lat")]
        public double lng { get; set; }
        [Display(Name = "Long")]
        public double obsValid { get; set; }

        public bool obsReviewed { get; set; }
        public bool locationPrivate { get; set; }
        public string subId { get; set; }
    }
}
