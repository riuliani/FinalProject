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
        public string comName { get; set; }
        public string sciName { get; set; }
        public string locId { get; set; }
        [Display(Name = "") ]
        public string locName { get; set; }
        public string obsDt { get; set; }
        public int howMany { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }
        public bool obsValid { get; set; }
        public bool obsReviewed { get; set; }
        public bool locationPrivate { get; set; }
        public string subId { get; set; }
    }
}
