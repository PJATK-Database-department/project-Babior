using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MarketWatch.Client.Services.Contracts;
using MarketWatch.Shared.Dtos;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;

namespace MarketWatch.Client.Services
{
    public class NewsService : INewsService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;
        private const string ApiKey = "3lXRRJe_tdBlWl4bxiuj4WWqaEQhB2df";

        public NewsService(HttpClient httpClient, IMemoryCache memoryCache)
        {
            _httpClient = httpClient;
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<NewsDto>> GetNewsByTicker(string ticker)
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var uriPolygon = $"https://api.polygon.io/v2/reference/news?ticker={ticker}&limit=5&apiKey={ApiKey}";
            var test = await _httpClient.GetAsync(uriPolygon);

            test.EnsureSuccessStatusCode();
            var jsonString = await test.Content.ReadAsStringAsync();

            var news = JObject.Parse(jsonString).SelectToken("results")?.ToObject<IEnumerable<NewsDto>>();

            return news;
        }

        // public async Task<IEnumerable<NewsDto>> GetNewsCache(string ticker)
        // {
        //     var output = ticker != null ? _memoryCache.Get<List<NewsDto>>(ticker) : new List<NewsDto>();
        //
        //     if (output is not null) return output;
        //     
        //     output = (await GetNewsByTicker(ticker)).ToList();
        //     _memoryCache.Set(ticker, output, TimeSpan.FromDays(1));
        //
        //     return output.ToList();
        // }
    }
}