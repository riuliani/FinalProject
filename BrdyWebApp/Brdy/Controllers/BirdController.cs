using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brdy.Data;
using Brdy.Data.Models;
using Brdy.Models;
using Brdy.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Brdy.Controllers
{
    public class BirdController : Controller
    {
        private readonly ILogger<BirdController> _logger;
        private readonly IBirdyServices _service;
        private readonly IWeatherServices _services;
        private readonly ApplicationDbContext _context;

        public BirdController(ILogger<BirdController> logger, IBirdyServices service, IWeatherServices services, ApplicationDbContext context)
        {
            _logger = logger;
            _service = service;
            _context = context;
            _services = services;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Seen()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SeenBirdList(BirdsSeenViewModel model)
        {
            var bird = new Bird();
            var weather = new Brdy.Data.Models.Weather();
            
            if (ModelState.IsValid)
            {
                bird.CommonName = model.CommonName;
                bird.ScientificName = model.ScientificName;
                bird.Lattatude = model.Latitude;
                bird.Longitude = model.Longitude;
            }

            var result = await _services.GetForecast(model.Latitude, model.Longitude);

            weather.Temperature = result.main.temp;

            _context.Add(bird);
            _context.Add(weather);

            await _context.SaveChangesAsync();

            var allBirds = _context.Birds.ToListAsync();
            return View(allBirds);
        }
        public IActionResult WishList()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SearchBirdByLocation(SightingDetail model)
        {
            var result = await _service.GetLocationAsync(model.locName);
            return View(result.OrderByDescending(x => x.howMany).Take(50));
        }

        [HttpGet]
        public async Task<IActionResult> SearchBirdBySpecies(SightingDetail model)
        {
            var result = await _service.GetSpeciesAsync(model.comName);
            return View(result);
        }
        [HttpGet]
        public async Task<IActionResult> Weather(SightingDetail model)
        {
            var result = await _services.GetForecast(model.lat, model.lng);
            return View(result);
        }        
    }
}