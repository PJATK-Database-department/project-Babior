using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketWatch.Server.Data;
using MarketWatch.Server.Entities;
using MarketWatch.Server.Entity;
using MarketWatch.Server.Exceptions;
using MarketWatch.Server.Repositories.Contracts;
using Microsoft.AspNetCore.Identity;
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

        public async Task<IEnumerable<Company>> GetCompanies(string userName)
        {
            var user = await _marketWatchContext.Users
                .Include(u => u.Companies)
                .Where(u => u.UserName == userName)
                .FirstOrDefaultAsync();

            //var companies = new CompanyList{ Results =  user.Companies};
            
            return user.Companies;
        }

        public async Task<Company> InsertCompany(JObject jsonObject, string userName)
        {
            var jsonString = JsonConvert.SerializeObject(jsonObject);
            var company = JObject.Parse(jsonString).ToObject<Company>();

            if (company == null) return company;
            
            var user = await _marketWatchContext.Users
                .Include(u => u.Companies)
                .Where(u => u.UserName == userName)
                .FirstOrDefaultAsync();

            if (user.Companies.Any(c => c.Ticker == company.Ticker)) return company;
            
            await _marketWatchContext.Companies.AddAsync(company);
            user.Companies.Add(company);
            await _marketWatchContext.SaveChangesAsync();

            return company;
        }
        
        public async Task DeleteCompany(string ticker)
        {
            var comp = GetCompanyByTicker(ticker).Result;
            _marketWatchContext.Companies.Remove(comp);
            await _marketWatchContext.SaveChangesAsync();
        }
        
        private async Task<Company> GetCompanyByTicker(string ticker)
        {
            var company = await _marketWatchContext.Companies.FirstOrDefaultAsync(c => c.Ticker == ticker);
            if (company == null)
            {
                throw new EntityNotFoundException(nameof(Company), ticker);
            }
            return company;
        }
    }
}