using System.Collections.Generic;
using System.Threading.Tasks;
using MarketWatch.Server.Data;
using MarketWatch.Server.Entities;
using MarketWatch.Server.Exceptions;
using MarketWatch.Server.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MarketWatch.Server.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _marketWatchContext;

        public CompanyRepository(ApplicationDbContext marketWatchContext)
        {
            _marketWatchContext = marketWatchContext;
        }

        public async Task<IEnumerable<Company>> GetCompanies()
        {
            var companies = await _marketWatchContext.Companies
                .Include(company => company.Branding).ToListAsync();

            return companies;
        }

        public async Task<Company> GetCompanyById(int id)
        {
            return await _marketWatchContext.Companies.FirstOrDefaultAsync(u => u.CompanyId == id);
        }

        public async Task<Company> GetCompanyByTicker(string ticker)
        {
            var company = await _marketWatchContext.Companies.FirstOrDefaultAsync(c => c.Ticker == ticker);
            if (company == null)
            {
                throw new EntityNotFoundException(nameof(Company), ticker);
            }
            return company;
        }

        public async Task<Company> InsertCompany(JObject jsonObject)
        {
            var jsonString = JsonConvert.SerializeObject(jsonObject);
            var company = JObject.Parse(jsonString).SelectToken("results").ToObject<Company>();

            await _marketWatchContext.Companies.AddAsync(company);

            await _marketWatchContext.SaveChangesAsync();

            return company;
        }
        
        public async Task DeleteCompany(string ticker)
        {
            var comp = GetCompanyByTicker(ticker).Result;
            _marketWatchContext.Companies.Remove(comp);
            await _marketWatchContext.SaveChangesAsync();
        }
    }
}