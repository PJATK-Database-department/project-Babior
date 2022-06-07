using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace MarketWatch.Server.Entities
{
    public class Branding
    {
        [Key]
        public int BrandingId { get; set; }
        [JsonProperty("logo_url")] public string? LogoUrl { get; set; }
        [JsonProperty("icon_url")]public string? IconUrl { get; set; }
    }
}