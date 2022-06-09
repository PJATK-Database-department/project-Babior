using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MarketWatch.Client.Services.Contracts;
using MarketWatch.Shared.Dtos;
using Newtonsoft.Json.Linq;

namespace MarketWatch.Client.Services
{
    public class PriceService : IPriceService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "3lXRRJe_tdBlWl4bxiuj4WWqaEQhB2df";

        public PriceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<IEnumerable<PriceDto>> GetPricesByTicker(string ticker)
        {
            //_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (ticker == null) return null;
            
            var today = DateTime.Now.ToString("yyyy-MM-dd");
            var todayYearAgo = DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd");
            
            
            var uriPolygon = $"https://api.polygon.io/v2/aggs/ticker/{ticker}/range/1/day/{todayYearAgo}/{today}?adjusted=true&sort=asc&apiKey={ApiKey}";
            var test = await _httpClient.GetAsync(uriPolygon);

            if (test.StatusCode == HttpStatusCode.BadRequest) return null;
            
            test.EnsureSuccessStatusCode();
            var jsonString = await test.Content.ReadAsStringAsync();
            
            PriceDto.CurrentDateTime = DateTime.Now.AddYears(-1);
            var stocks = JObject.Parse(jsonString).SelectToken("results").ToObject<IEnumerable<PriceDto>>();
            
            return stocks;
        }
    }
}