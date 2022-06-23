using System.Threading.Tasks;
using MarketWatch.Server.Extensions;
using MarketWatch.Server.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace MarketWatch.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCompanies([FromQuery(Name = "userName")] string userName)
        {
            var companies = await _companyRepository.GetCompanies(userName);

            var companiesDtos = companies.ConvertToDtos();
            return Ok(companiesDtos);
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany([FromBody] JObject requestBody, [FromQuery(Name = "userName")] string userName)
        {
            var company = await _companyRepository.InsertCompany(requestBody, userName);

            var companyDtos = company.ConvertToDto();
            return Ok(companyDtos);
        }
        
        [HttpDelete("{ticket}")]
        public async Task<IActionResult> DeleteCompany([FromRoute] string ticket)
        {
            await _companyRepository.DeleteCompany(ticket);
            return Ok();
        }
    }
}