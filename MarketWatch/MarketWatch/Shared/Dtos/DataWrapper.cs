using System.Collections.Generic;

namespace MarketWatch.Shared.Dtos
{
    public class DataWrapper
    {
        public CompanyDto Company { get; set; }
        public List<PriceDto> Stocks { get; set; }
        public List<NewsDto> News { get; set; }
    }
}