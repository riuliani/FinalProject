using Brdy.Models;
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
        private readonly HttpClient _client2;
        public BirdyServices(HttpClient client, HttpClient client2)
        {
            _client = client;
            _client2 = client2;
        }

        public async Task<IEnumerable<SightingDetail>> GetLocationAsync(string locName)
        {
            return await _client.GetFromJsonAsync<IEnumerable<SightingDetail>>($"data/obs/{locName}/recent");
        }
        public async Task<IEnumerable<SightingDetail>> GetSpeciesAsync(string comName)
        {
            return await _client.GetFromJsonAsync<IEnumerable<SightingDetail>>($"data/obs/{comName}/recent");
        }

        public async Task<IEnumerable<Forecast>> GetForecast(float lat, float lon)
        {
            return await _client2.GetFromJsonAsync<IEnumerable<Forecast>>($"lat={lat}&lon={lon}");
        }
    }
}
