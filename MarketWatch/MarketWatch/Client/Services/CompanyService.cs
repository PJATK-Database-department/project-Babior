using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using MarketWatch.Client.Services.Contracts;
using MarketWatch.Shared.Dtos;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MarketWatch.Client.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly HttpClient _httpClient;
        public const string BaseUrl = "https://api.polygon.io";
        private readonly string _apiKey = "3lXRRJe_tdBlWl4bxiuj4WWqaEQhB2df";

        public CompanyService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            //_apiKey = configuration["PolygonApiKey"];
        }

        public async Task<IEnumerable<CompanyDto>> GetCompanies(string userName)
        {
            if (userName == null) return new List<CompanyDto>();
            
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var uriApi = $"api/Company?{userName}";
            var response = await _httpClient.GetAsync(uriApi);

            //response.EnsureSuccessStatusCode();
            if (!response.IsSuccessStatusCode) return new List<CompanyDto>();
            
            var jsonString = await response.Content.ReadAsStringAsync();

            //var companies = JObject.Parse(jsonString).ToObject<IEnumerable<CompanyDto>>();
            //var companies = JsonConvert.DeserializeObject<IEnumerable<CompanyDto>>(jsonString);
            
            
            var companies = JsonConvert.DeserializeObject<List<CompanyDto>>(jsonString);
            
            return companies;
        }

        public async Task<IEnumerable<CompanyDto>> GetCompaniesByName(string name)
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var uriPolygon =
                $"{BaseUrl}/v3/reference/tickers?search={name}&active=true&sort=ticker&order=asc&apikey={_apiKey}";
            var response = await _httpClient.GetAsync(uriPolygon);
            response.EnsureSuccessStatusCode();
            
            var jsonString = await response.Content.ReadAsStringAsync();
            
            var companies = JObject.Parse(jsonString).SelectToken("results").ToObject<IEnumerable<CompanyDto>>();

            return companies;
        }

        public async Task<CompanyDto> GetCompanyByTicker(string ticker)
        {
            var uriPolygon = $"https://api.polygon.io/v3/reference/tickers/{ticker}?apiKey={_apiKey}";
            var response = await _httpClient.GetAsync(uriPolygon);
            response.EnsureSuccessStatusCode();
            
            var jsonString = await response.Content.ReadAsStringAsync();
            
            var company = JObject.Parse(jsonString).SelectToken("results").ToObject<CompanyDto>();

            return company;
        }

        public async Task AddCompanyToWatchlist(CompanyDto companyDto, string userName)
        {
            
            var jsonString = JsonConvert.SerializeObject(companyDto, Formatting.Indented);
            var uriApi = $"api/Company?{userName}";

            await _httpClient.PostAsync(uriApi, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public async Task DeleteCompany(string ticker)
        {
            await _httpClient.DeleteAsync($"/api/Company/{ticker}");
        }
    }
}