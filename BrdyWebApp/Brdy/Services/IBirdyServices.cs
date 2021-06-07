using Brdy.Models;
using System.Threading.Tasks;

namespace Brdy.Services
{
    public interface IBirdyServices
    {
        Task<SightingDetail> GetLocationAsync(string locName);
        Task<SightingDetail> GetSpeciesAsync(string comName);
    }
}