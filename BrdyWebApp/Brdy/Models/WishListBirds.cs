using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Brdy.Models
{
    public class WishListBirds
    {
        [Display(Name = "Common Name")]
        public string CommonName { get; set; }
    }
}
