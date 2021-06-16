using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brdy.Data;
using Brdy.Data.Models;
using Brdy.Models;
using Brdy.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Brdy.Controllers
{
    public class SeenBirdController : Controller
    {
        private readonly ILogger<SeenBirdController> _logger;
        private readonly IBirdyServices _service;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public SeenBirdController(ILogger<SeenBirdController> logger, IBirdyServices service, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _service = service;
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Seen()
        {            
            return View();
        }
        public IActionResult AddToSeenList(BirdsSeenViewModel model)
        {
            var bird = new SeenBirds();
            if (ModelState.IsValid)
            {
                bird.CommonName = model.CommonName;
                bird.Lattatude = model.Latitude;
                bird.Longitude = model.Longitude;
            }

            _context.SeenBirds.Add(bird);

            return RedirectToAction("SeenList");
        }

        public async Task<IActionResult> SeenList()
        {           
            var userId = _userManager.GetUserId(User);           
            return View(await _context.SeenBirds.Where(X => X.User.Id == userId).ToListAsync());
        }       
    }
}