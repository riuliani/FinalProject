using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Brdy.Data.Models
{
    public class Bird
    {
        [Key]
        public int BirdId { get; set; }
        [Required]
        public string CommonName { get; set; }
        [Required]
        public string ScientificName { get; set; }
        public double Lattatude { get; set; }
        public double Longitude { get; set; }
        public IdentityUser Identity { get; set; }


    }
}
