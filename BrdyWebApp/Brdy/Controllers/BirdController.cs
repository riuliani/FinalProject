using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brdy.Data;
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
        public IActionResult Seen(SightingDetail model)
        {
            return View();
        }
        public IActionResult WishList()
        {
            return View();
        }

    
        [HttpGet]
        public async Task<IActionResult> GetRecent()
        {
            var result = await _service.GetRecentAsync();
            return View(result);
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
        public async Task<IActionResult> Weather(Forecast model)
        {
            var result = await _services.GetForecast(model.lat, model.lon);
            return View(result);
        }        
    }
}