using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MarketWatch.Client.Services.Contracts;
using MarketWatch.Shared.Dtos;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json.Linq;

namespace MarketWatch.Client.Services
{
    public class PriceService : IPriceService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;
        private const string ApiKey = "3lXRRJe_tdBlWl4bxiuj4WWqaEQhB2df";

        public PriceService(HttpClient httpClient, IMemoryCache memoryCache)
        {
            _httpClient = httpClient;
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<PriceDto>> GetPricesByTicker(string ticker)
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            if (ticker == null) return new List<PriceDto>();
            try
            {
                var today = DateTime.Now.ToString("yyyy-MM-dd");
                var todayYearAgo = DateTime.Now.AddYears(-1).ToString("yyyy-MM-dd");


                var uriPolygon =
                    $"https://api.polygon.io/v2/aggs/ticker/{ticker}/range/1/day/{todayYearAgo}/{today}?adjusted=true&sort=asc&apiKey={ApiKey}";
                var test = await _httpClient.GetAsync(uriPolygon);

                if (test.StatusCode == HttpStatusCode.BadRequest) return null;

                test.EnsureSuccessStatusCode();
                var jsonString = await test.Content.ReadAsStringAsync();

                PriceDto.CurrentDateTime = DateTime.Now.AddYears(-1);
                var stocks = JObject.Parse(jsonString).SelectToken("results")?.ToObject<IEnumerable<PriceDto>>();
                
                return stocks == null || stocks.Count() == 5 ? new List<PriceDto>() : stocks.ToList();
            }
            catch (Exception ex)
            {
                //catch 429
                //catch wrong prices list exc
            }
            
            return new List<PriceDto>();
        }

        // public async Task<IEnumerable<PriceDto>> GetPricesCache(string ticker)
        // {
        //     var output = ticker != null ? _memoryCache.Get<List<PriceDto>>(ticker) : new List<PriceDto>();
        //
        //     if (output is not null) return output;
        //     
        //     output = (await GetPricesByTicker(ticker)).ToList();
        //     _memoryCache.Set(ticker, output, TimeSpan.FromDays(1));
        //
        //     return output;
        // }
    }
}