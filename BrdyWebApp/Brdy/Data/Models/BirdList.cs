using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brdy.Data
{
    public class BirdList
    {
        public int Id { get; set; }
        public string CommonName { get; set; }
        public string ScientificName { get; set; }
        public bool Observed { get; set; }
        public bool WantToSee { get; set; }
    }
}
