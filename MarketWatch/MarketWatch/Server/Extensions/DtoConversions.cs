using System.Collections.Generic;
using System.Linq;
using MarketWatch.Server.Entities;
using MarketWatch.Server.Entity;
using MarketWatch.Shared.Dtos;

namespace MarketWatch.Server.Extensions
{
    public static class DtoConversions
    {
        public static CompanyList ConvertToDtos(this IEnumerable<Company> companies)
        {
            if (companies == null || !companies.Any())
            {
                return new CompanyList();
            }

            var test = (from company in companies
                select ConvertToDto(company));  


            return new CompanyList
            {
                Results = test
            };
            ;
        }

        public static CompanyDto ConvertToDto(this Company company)
        {
            return new CompanyDto
            {
                Ticker = company.Ticker,
                Name = company.Name,
                Location = company.Location,
                Branding = GetBrandingDto(company),
                Equity = company.Equity,
                Description = company.Description,
                TotalEmployees = company.TotalEmployees
            };
        }

        private static BrandingDto GetBrandingDto(Company company)
        {
            return new BrandingDto
            {
                LogoUrl = company.LogoUrl,
                IconUrl = company.IconUrl
            };
        }
    }
}