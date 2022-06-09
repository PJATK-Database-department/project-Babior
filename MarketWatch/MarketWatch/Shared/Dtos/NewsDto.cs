using System;
using Newtonsoft.Json;

namespace MarketWatch.Shared.Dtos
{
    public class NewsDto
    {
        public Publisher Publisher { get; set; }
        [JsonProperty("title")]
        public string ArticleTitle { get; set; }
        [JsonProperty("published_utc")]
        public DateTime PublishedDate { get; set; }
        [JsonProperty("article_url")]
        public string ArticleUrl { get; set; }
    }
}