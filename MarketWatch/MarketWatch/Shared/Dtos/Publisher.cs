using Newtonsoft.Json;

namespace MarketWatch.Shared.Dtos
{
    public class Publisher
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("homepage_url")]
        public string HomePageUrl { get; set; }
    }
}