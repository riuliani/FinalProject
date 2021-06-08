using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brdy.Data.Models
{
    public class Weather
    {
        public int WeatherId { get; set; }
        public DateTime DateTime { get; set; }
        public double Temperature { get; set; }
        public string Forecast { get; set; }
    }
}
