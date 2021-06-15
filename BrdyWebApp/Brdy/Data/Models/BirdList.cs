using Brdy.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Brdy.Data
{
    public class BirdList
    {
        [Key]
        public int BirdId { get; set; }
        [Required]
        [MaxLength(50)]
        public string CommonName { get; set; }
        [MaxLength(50)]
        public string ScientificName { get; set; }
        public bool Observed { get; set; }
        public bool WantToSee { get; set; }

        public List<Location> Locations { get; set; }
    }
}
