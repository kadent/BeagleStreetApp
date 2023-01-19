using BeagleStreetApp.Models;
using BeagleStreetApp.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace BeagleStreetApp.Test
{
    [TestClass]
    public class WeatherServiceTests
    {
        private IWeatherService _weatherService;
            
        public WeatherServiceTests()
        {
            WebApplicationFactory<Program> webAppFactory = new WebApplicationFactory<Program>();
            _weatherService = webAppFactory.Services.GetService<IWeatherService>();
        }

        [TestMethod]
        [ExpectedException(typeof(HttpRequestException))]
        public async Task GetCurrentWeather_ThrowsExceptionForInvalidLocation()
        {
            await _weatherService.GetCurrentWeather("fakelocation");
        }

        [TestMethod]
        public async Task GetCurrentWeather_ReturnsWeatherForValidLocation()
        {
            Weather weather = await _weatherService.GetCurrentWeather("London");

            Assert.IsNotNull(weather);
            Assert.IsNotNull(weather.Location);
            Assert.IsNotNull(weather.WeatherDetails.CurrentTemp);
            Assert.IsNotNull(weather.WeatherDetails.MinimumTemp);
            Assert.IsNotNull(weather.WeatherDetails.MaximumTemp);
            Assert.IsNotNull(weather.WeatherDetails.Humidity);
            Assert.IsNotNull(weather.WeatherDetails.Pressure);
            Assert.IsNotNull(weather.SunDetails.Sunrise);
            Assert.IsNotNull(weather.SunDetails.Sunset);
            Assert.AreNotEqual(0, weather.DisplayDetails.Count);
            Assert.IsNotNull(weather.DisplayDetails.ToArray()[0].Name);
            Assert.IsNotNull(weather.DisplayDetails.ToArray()[0].Description);
            Assert.IsNotNull(weather.DisplayDetails.ToArray()[0].Icon);
            Assert.IsNotNull(weather.DisplayDetails.ToArray()[0].Id);
        }
    }
}