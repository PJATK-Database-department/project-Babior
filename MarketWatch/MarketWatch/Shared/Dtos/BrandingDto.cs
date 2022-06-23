using Newtonsoft.Json;

namespace MarketWatch.Shared.Dtos
{
    public class BrandingDto
    {
        [JsonProperty("logo_url")] public string? LogoUrl { get; set; }
        [JsonProperty("icon_url")]public string? IconUrl { get; set; }
    }
}