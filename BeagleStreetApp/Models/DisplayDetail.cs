using Newtonsoft.Json;

namespace BeagleStreetApp.Models
{
    public record DisplayDetail
    {
        public int Id { get; set; }
        [JsonProperty("main")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
