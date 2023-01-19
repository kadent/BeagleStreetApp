using BeagleStreetApp.Models;
using System.Web;

namespace BeagleStreetApp.Services
{
    // TODO: Implement interface
    public class WeatherService : IWeatherService
    {
        readonly string _apiUrl;
        readonly string _apiToken;
        static readonly HttpClient _httpClient = new HttpClient();

        public WeatherService(string apiUrl, string apiToken)
        {
            _apiUrl = apiUrl;
            _apiToken = apiToken;
        }

        /// <summary>
        /// Fetches the weather for a given locationName
        /// </summary>
        /// <param name="locationName"></param>
        /// <returns>BeagleStreetApp.Models.Weather</returns>
        /// <exception cref="HttpRequestException"></exception>
        public async Task<Weather> GetCurrentWeather(string locationName)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"{_apiUrl}/weather?q={HttpUtility.UrlEncode(locationName)}&units=metric&appid={_apiToken}");

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException(response.ToString(), null, response.StatusCode);
            }

            return await response.Content.ReadAsAsync<Weather>();
        }
    }
}
