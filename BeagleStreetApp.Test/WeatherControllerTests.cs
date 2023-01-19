using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;

namespace BeagleStreetApp.Test
{
    [TestClass]
    public class WeatherControllerTests
    {
        private HttpClient _httpClient;
        private static string _controllerUri = "api/v1/weather";

        public WeatherControllerTests()
        {
            WebApplicationFactory<Program> webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
        }

        [TestMethod]
        public async Task GetRoute_Returns404ForInvalidLocation()
        {
            var response = await _httpClient.GetAsync($"{_controllerUri}/fakelocation");

            int expected = 404;
            int actual = (int)response.StatusCode;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task GetRoute_Returns200ForValidLocation()
        {
            var response = await _httpClient.GetAsync($"{_controllerUri}/London");

            int expected = 200;
            int actual = (int)response.StatusCode;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public async Task GetRoute_ReturnsCorrectLocation()
        {
            string location = "London";

            var response = await _httpClient.GetAsync($"{_controllerUri}/{location}");
            var responseContent = await response.Content.ReadAsStringAsync();
            dynamic json = JsonConvert.DeserializeObject(responseContent);

            string expected = location;
            string actual = json["location"];

            Assert.AreEqual(expected, actual);
        }
    }
}