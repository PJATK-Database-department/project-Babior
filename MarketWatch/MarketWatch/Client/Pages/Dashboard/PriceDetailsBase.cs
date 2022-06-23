using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketWatch.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace MarketWatch.Client.Pages.Dashboard
{
    public class PriceDetailsBase : ComponentBase
    {
        [Parameter] public List<PriceDto> Stocks { get; set; }
        [Parameter] public bool IsCompanyChosen { get; set; }
        protected PriceDto LastPrice { get; set; }

        protected override async Task OnParametersSetAsync()
        {
            if (Stocks is {Count: > 0})
            {
                LastPrice = Stocks.Where(x => x != null).ToList().Last();
            }
            await base.OnParametersSetAsync();
        }
    }
}