using Brdy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Brdy.Services
{
    public class WeatherServices : IWeatherServices
    {
        private readonly HttpClient _client;
        public WeatherServices(HttpClient client)
        {
            _client = client;
        }
        public async Task<Forecast> GetForecast(double lat, double lon)
        {
            return await _client.GetFromJsonAsync<Forecast>($"?lat={lat}&lon={lon}");
        }
    }
}
