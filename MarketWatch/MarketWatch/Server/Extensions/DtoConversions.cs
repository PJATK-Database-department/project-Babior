using System.Collections.Generic;
using System.Linq;
using MarketWatch.Server.Entities;
using MarketWatch.Shared.Dtos;

namespace MarketWatch.Server.Extensions
{

    public static class DtoConversions
    {
        private const string ApiKey = "3lXRRJe_tdBlWl4bxiuj4WWqaEQhB2df";
        public static IEnumerable<CompanyDto> ConvertToDtos(this IEnumerable<Company> companies)
        {
            if (companies == null)
            {
                return null;
            }

            return (from company in companies
                select new CompanyDto
                {
                    Ticker = company.Ticker,
                    Name = company.Name,
                    Location = company.Location,
                    LogoUrl = GetLogoUrl(company),
                    Equity = company.Equity,
                    Description = company.Description
                }).ToList();
        }

        public static CompanyDto ConvertToDto(this Company company)
        {
            return new CompanyDto
            {
                Ticker = company.Ticker,
                Name = company.Name,
                Location = company.Location,
                LogoUrl = company.Branding.LogoUrl + $"?apiKey={ApiKey}"
            };
        }

        private static string GetLogoUrl(Company company)
        {
            if (company.Branding == null)
            {
                return "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ac/No_image_available.svg/1024px-No_image_available.svg.png";
            }

            if (company.Branding.LogoUrl == null)
            {
                return company.Branding.IconUrl + $"?apiKey={ApiKey}";
            }

            return company.Branding.LogoUrl + $"?apiKey={ApiKey}";
        }
    }
}