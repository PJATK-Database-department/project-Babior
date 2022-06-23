using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MarketWatch.Server.Entity;
using MarketWatch.Shared.Dtos;
using Newtonsoft.Json;

namespace MarketWatch.Server.Entities
{
    public class Company
    {
        [Key] public int CompanyId { get; set; }
        [JsonProperty("ticker")] public string Ticker { get; set; }
        [JsonProperty("name")] public string Name { get; set; }
        [JsonProperty("locale")] public string Location { get; set; }
        [JsonProperty("primary_exchange")] public string Equity { get; set; }
        
        [JsonProperty("total_employees")] public int TotalEmployees { get; set; }
        [JsonProperty("description")] public string Description { get; set; }

        [NotMapped]
        [JsonProperty("branding")]
        public BrandingDto Branding
        {
            set
            {
                if (value == null) return;
                LogoUrl = value.LogoUrl;
                IconUrl = value.IconUrl;
            }
        }

        [JsonProperty("logo_url")] public string LogoUrl { get; set; }
        
        [JsonProperty("icon_url")] public string IconUrl { get; set; }
        
        public ICollection<ApplicationUser> Users { get; set; }
    }
}