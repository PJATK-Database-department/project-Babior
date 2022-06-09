using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using MarketWatch.Client.Services.Contracts;
using MarketWatch.Shared.Dtos;
using Newtonsoft.Json.Linq;

namespace MarketWatch.Client.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly HttpClient _httpClient;
        private const string ApiKey = "3lXRRJe_tdBlWl4bxiuj4WWqaEQhB2df";

        public CompanyService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CompanyDto>> GetCompanies()
        {
            var companies = await _httpClient.GetFromJsonAsync<IEnumerable<CompanyDto>>("api/Company");
            return companies;
        }

        public async Task<IEnumerable<CompanyDto>> GetCompaniesByName(string name)
        {
            //_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var uriPolygon =
                $"https://api.polygon.io/v3/reference/tickers?search={name}&active=true&sort=ticker&order=asc&apikey={ApiKey}";
            var response = await _httpClient.GetAsync(uriPolygon);
            response.EnsureSuccessStatusCode();
            
            var jsonString = await response.Content.ReadAsStringAsync();
            
            var companies = JObject.Parse(jsonString).SelectToken("results").ToObject<IEnumerable<CompanyDto>>();

            return companies;
        }

        public async Task AddCompanyByTicker(string ticker)
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var uriPolygon = $"https://api.polygon.io/v3/reference/tickers/{ticker}?date=2022-06-28&apikey={ApiKey}";
            var response = await _httpClient.GetAsync(uriPolygon);

            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();

            var uriApi = "api/Company";
            await _httpClient.PostAsync(uriApi, new StringContent(jsonString, Encoding.UTF8, "application/json"));
        }

        public async Task DeleteCompany(string ticker)
        {
            await _httpClient.DeleteAsync($"/api/Company/{ticker}");
        }
    }
}