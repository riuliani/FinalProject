using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Brdy.Data.Models
{
    public class Weather
    {
        [Key]
        public int WeatherId { get; set; }
        public double Temperature { get; set; }
        public string Forecast { get; set; }


        public int BirdId { get; set; }


    }
}
