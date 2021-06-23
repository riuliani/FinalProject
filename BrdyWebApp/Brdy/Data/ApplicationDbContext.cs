using Brdy.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Brdy.Models;

namespace Brdy.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<SeenBirds> SeenBirds { get; set; }
        public DbSet<WishList> WishList { get; set; }
        public DbSet<Brdy.Models.BirdsSeenViewModel> BirdsSeenViewModel { get; set; }

    }
}
