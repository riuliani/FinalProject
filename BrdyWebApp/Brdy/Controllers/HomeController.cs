﻿using Brdy.Models;
using Brdy.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Brdy.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBirdyServices _service;

        public HomeController(ILogger<HomeController> logger, IBirdyServices service)
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



        public IActionResult Privacy()
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
            var result = await _service.GetForecast(model.lat, model.lng);
            return View(result);
        }

        //public async Task<IActionResult> SearchRecentAsync()
        //{
        //    var result = await _service.GetRecentAsync();
        //    return View(result);

        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
