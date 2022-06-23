using System.Collections.Generic;
using System.Security;
using System.Threading.Tasks;
using MarketWatch.Server.Entities;
using MarketWatch.Server.Entity;
using Newtonsoft.Json.Linq;

namespace MarketWatch.Server.Repositories.Contracts
{

    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetCompanies(string userName);
        Task<Company> InsertCompany(JObject jsonObject, string userName);

        Task DeleteCompany(string ticker);
    }
}