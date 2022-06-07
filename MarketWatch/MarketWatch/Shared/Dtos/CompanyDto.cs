using Newtonsoft.Json;

namespace MarketWatch.Shared.Dtos
{
    public class CompanyDto
    {
        public string Ticker { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string LogoUrl { get; set; }

        [JsonProperty("primary_exchange")]
        public string Equity { get; set; }
        public string Description { get; set; }
    }
}