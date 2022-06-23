using System.Collections.Generic;
using System.Threading.Tasks;
using MarketWatch.Shared.Dtos;

namespace MarketWatch.Client.Services.Contracts
{
    public interface INewsService
    {
        Task<IEnumerable<NewsDto>> GetNewsByTicker(string ticker);
        // Task<IEnumerable<NewsDto>> GetNewsCache(string ticker);
    }
}