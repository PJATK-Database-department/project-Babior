using System.Collections.Generic;
using System.Threading.Tasks;
using MarketWatch.Shared.Dtos;

namespace MarketWatch.Client.Services.Contracts
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDto>> GetCompanies();
        Task<IEnumerable<CompanyDto>> GetCompaniesByName(string name);
        Task AddCompanyByTicker(string ticker);
        Task DeleteCompany(string ticker);
    }
}