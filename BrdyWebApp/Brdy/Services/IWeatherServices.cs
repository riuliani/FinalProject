using Brdy.Models;
using System.Threading.Tasks;

namespace Brdy.Services
{
    public interface IWeatherServices
    {
        Task<Forecast> GetForecast(double lat, double lon);
    }
}