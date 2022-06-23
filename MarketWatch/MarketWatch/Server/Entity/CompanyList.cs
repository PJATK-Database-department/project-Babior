using System.Collections;
using System.Collections.Generic;
using MarketWatch.Server.Entities;
using MarketWatch.Shared.Dtos;

namespace MarketWatch.Server.Entity
{
    public class CompanyList
    {
        public IEnumerable<CompanyDto> Results { get; set; }
    }
}