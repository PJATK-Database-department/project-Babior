using System.Collections.Generic;
using System.Threading.Tasks;
using MarketWatch.Server.Entities;
using Newtonsoft.Json.Linq;

namespace MarketWatch.Server.Repositories.Contracts
{

    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetCompanies();
        Task<Company> GetCompanyById(int id);
        Task<Company> GetCompanyByTicker(string ticker);

        Task<Company> InsertCompany(JObject jsonObject);

        Task DeleteCompany(string ticker);
    }
}