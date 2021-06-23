﻿using Brdy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Brdy.Services
{
    public class BirdyServices : IBirdyServices
    {
        private readonly HttpClient _client;
        public BirdyServices(HttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<SightingDetail>> GetLocationAsync(string locName)
        {
            return await _client.GetFromJsonAsync<IEnumerable<SightingDetail>>($"data/obs/{locName}/recent");
        }
        public async Task<IEnumerable<SightingDetail>> GetRecentAsync(double lat, double lng)
        {
            return await _client.GetFromJsonAsync<IEnumerable<SightingDetail>>($"data/obs/geo/recent?lat={lat}&lng={lng}");
        }

    }
}
