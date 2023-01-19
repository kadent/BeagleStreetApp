using Newtonsoft.Json;

namespace BeagleStreetApp.Models
{
    public record WeatherDetails
    {
        [JsonProperty("temp")]
        public decimal CurrentTemp { get; set; }
        [JsonProperty("temp_min")]
        public decimal MinimumTemp { get; set; }
        [JsonProperty("temp_max")]
        public decimal MaximumTemp { get; set; }
        [JsonProperty("pressure")]
        public int Pressure { get; set; }
        [JsonProperty("humidity")]
        public int Humidity { get; set; }
    }
}
