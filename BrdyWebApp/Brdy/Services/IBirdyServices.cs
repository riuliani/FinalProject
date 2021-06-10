using Brdy.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Brdy.Services
{
    public interface IBirdyServices
    {
        //Task<IEnumerable<Forecast>> GetForecast(float lat, float lon);
        Task<IEnumerable<SightingDetail>> GetLocationAsync(string locName);
        Task<IEnumerable<SightingDetail>> GetSpeciesAsync(string comName);
    }
}