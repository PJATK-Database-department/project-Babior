using System;
using Newtonsoft.Json;

namespace MarketWatch.Shared.Dtos
{
    public class PriceDto
    {
        [JsonProperty("o")] public Double Open { get; set; }
        [JsonProperty("c")] public Double Close { get; set; }
        [JsonProperty("h")] public Double High { get; set; }
        [JsonProperty("l")] public Double Low { get; set; }
        [JsonProperty("v")] public Double Volume { get; set; }
        public DateTime Date { get; set; }
        public static DateTime CurrentDateTime { get; set; }

        public PriceDto()
        {
            Date = CurrentDateTime;
            CurrentDateTime = CurrentDateTime.AddDays(1);
        }
    }
}