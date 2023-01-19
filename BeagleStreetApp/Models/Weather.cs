using Newtonsoft.Json;

namespace BeagleStreetApp.Models
{
    public record Weather
    {
        [JsonProperty("name")]
        public string Location { get; set; }
        [JsonProperty("main")]
        public WeatherDetails WeatherDetails { get; set; }
        [JsonProperty("weather")]
        public ICollection<DisplayDetail> DisplayDetails { get; set; }
        [JsonProperty("sys")]
        public SunDetails SunDetails { get; set; }
    }
}
