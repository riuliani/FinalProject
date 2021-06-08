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
        public string Location { get; set; }

        public int BirdsId { get; set; }
        public BirdList BirdList { get; set; }
    }
}
