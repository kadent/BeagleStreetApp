using BeagleStreetApp.Models;
using BeagleStreetApp.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BeagleStreetApp.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly ILogger<WeatherController> _logger;

        public WeatherController(ILogger<WeatherController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("{location}")]
        public async Task<IActionResult> Get([FromServices] IWeatherService weatherService, string location)
        {
            try
            {
                Weather weather = await weatherService.GetCurrentWeather(location);
                return Ok(weather);
            }
            catch (HttpRequestException e)
            {
                if (e.StatusCode == HttpStatusCode.NotFound)
                {
                    return NotFound();
                }

                _logger.LogError(e.Message);

                return BadRequest(e.Message);
            }
        }
    }
}