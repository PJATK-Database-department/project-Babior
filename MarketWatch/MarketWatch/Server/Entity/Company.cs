using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace MarketWatch.Server.Entities
{
    public class Company
    {
        [Key] public int CompanyId { get; set; }
        public string Ticker { get; set; }
        public string Name { get; set; }
        [JsonProperty("locale")] public string Location { get; set; }
        [JsonProperty("primary_exchange")] public string Equity { get; set; }
        public string Description { get; set; }
        public Branding Branding { get; set; }
    }
}