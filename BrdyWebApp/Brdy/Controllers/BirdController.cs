using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Brdy.Models;
using Brdy.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Brdy.Controllers
{
    public class BirdController : Controller
    {
        private readonly ILogger<BirdController> _logger;
        private readonly IBirdyServices _service;

        public BirdController(ILogger<BirdController> logger, IBirdyServices service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Seen()
        {
            return View();
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
        //[HttpGet]
        //public async Task<IActionResult> Weather(SightingDetail model)
        //{
        //    var result = await _service.GetForecast(model.lat, model.lng);
        //    return View(result);
        //}

        //public async Task<IActionResult> SearchRecentAsync()
        //{
        //    var result = await _service.GetRecentAsync();
        //    return View(result);
        //}
    }
}