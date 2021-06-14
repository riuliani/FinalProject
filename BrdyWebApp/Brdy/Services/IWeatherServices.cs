using Brdy.Models;
using System.Threading.Tasks;

namespace Brdy.Services
{
    public interface IWeatherServices
    {
        Task<CurrentWeather> GetForecast(double lat, double lon);
    }
}