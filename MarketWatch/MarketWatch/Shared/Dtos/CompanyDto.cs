using Newtonsoft.Json;

namespace MarketWatch.Shared.Dtos
{
    public class CompanyDto
    {
        [JsonProperty("ticker")] public string Ticker { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("locale")] public string Location { get; set; }
        [JsonProperty("branding")] public BrandingDto Branding { get; set; }

        [JsonIgnore] public string LogoUrl
        {
            get
            {
                if (Branding == null)
                {
                    return
                        "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ac/No_image_available.svg/1024px-No_image_available.svg.png";
                }

                return Branding.LogoUrl == null ? $"{Branding.IconUrl}?apiKey=3lXRRJe_tdBlWl4bxiuj4WWqaEQhB2df" : $"{Branding.LogoUrl}?apiKey=3lXRRJe_tdBlWl4bxiuj4WWqaEQhB2df";
            }
        }

        [JsonProperty("primary_exchange")] public string Equity { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("total_employees")] public int TotalEmployees { get; set; }
    }
}