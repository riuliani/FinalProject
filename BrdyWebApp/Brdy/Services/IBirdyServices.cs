using Brdy.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Brdy.Services
{
    public interface IBirdyServices
    {        
        Task<IEnumerable<SightingDetail>> GetLocationAsync(string locName);
        Task<IEnumerable<SightingDetail>> GetSpeciesAsync(string comName);
        Task<IEnumerable<SightingDetail>> GetRecentAsync();
    }
}