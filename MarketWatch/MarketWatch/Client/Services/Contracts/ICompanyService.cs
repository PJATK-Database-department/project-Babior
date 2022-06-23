using System.Collections.Generic;
using System.Threading.Tasks;
using MarketWatch.Shared.Dtos;

namespace MarketWatch.Client.Services.Contracts
{
    public interface ICompanyService
    {
        Task<IEnumerable<CompanyDto>> GetCompanies(string userName);
        Task<IEnumerable<CompanyDto>> GetCompaniesByName(string name);
        Task<CompanyDto> GetCompanyByTicker(string ticker);
        Task AddCompanyToWatchlist(CompanyDto companyDto, string userName);
        Task DeleteCompany(string ticker);
    }
}