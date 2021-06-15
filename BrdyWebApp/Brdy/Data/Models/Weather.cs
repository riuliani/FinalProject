using System;
using System.ComponentModel.DataAnnotations;

namespace Brdy.Data.Models
{
    public class Weather
    {
        [Key]
        public int WeatherId { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        public double Temperature { get; set; }
        public string Forecast { get; set; }

        public int BirdId { get; set; }
    }
}
