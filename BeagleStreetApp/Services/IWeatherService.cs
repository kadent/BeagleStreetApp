using BeagleStreetApp.Models;
using System.Net.Http;

namespace BeagleStreetApp.Services
{
    public interface IWeatherService
    {
        public Task<Weather> GetCurrentWeather(string locationName);
    }
}
