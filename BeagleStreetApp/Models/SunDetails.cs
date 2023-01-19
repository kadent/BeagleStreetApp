using Newtonsoft.Json;

namespace BeagleStreetApp.Models
{
    public record SunDetails
    {
        [JsonProperty("sunrise")]
        public int Sunrise { get; set; }

        [JsonProperty("sunset")]
        public int Sunset { get; set; }
    }
}
