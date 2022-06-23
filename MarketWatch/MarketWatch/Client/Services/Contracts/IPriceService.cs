using System.Collections.Generic;
using System.Threading.Tasks;
using MarketWatch.Shared.Dtos;

namespace MarketWatch.Client.Services.Contracts
{
    public interface IPriceService
    {
        Task<IEnumerable<PriceDto>> GetPricesByTicker(string ticker);
        // Task<IEnumerable<PriceDto>> GetPricesCache(string ticker);
    }
}