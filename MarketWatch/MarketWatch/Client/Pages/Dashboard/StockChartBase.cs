using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketWatch.Client.Services.Contracts;
using MarketWatch.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Charts;

namespace MarketWatch.Client.Pages.Dashboard
{
    public class StockChartBase : ComponentBase
    {
        [Inject] public IPriceService PriceService { get; set; }
        [Parameter] public bool IsCompanyChosen { get; set; }
        [Parameter] public DataWrapper Data { get; set; }

        [Parameter] public PriceDto LastPrice { get; set; }
        protected SfStockChart StockChart { get; set; }

        protected override void OnInitialized()
        {
            Data.Stocks = new List<PriceDto>();
        }

        protected override async Task OnParametersSetAsync()
        {
            StockChart?.Refresh();
            StateHasChanged();
            await base.OnParametersSetAsync();
        }
    }
}