using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketWatch.Client.Services.Contracts;
using MarketWatch.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace MarketWatch.Client.Pages.Dashboard
{
    public class StockChartBase : ComponentBase
    {
        [Inject] public IPriceService PriceService { get; set; }

        public List<PriceDto> Stocks { get; set; }

        [Parameter] public string TickerName { get; set; }
        [Parameter] public bool IsCompanyChosen { get; set; }
        private bool SpinnerVisible { get; set; }

        private async void LoadStocksData()
        {
            SpinnerVisible = true;
            if (!IsCompanyChosen) return;
            var response = await PriceService.GetPricesByTicker(TickerName);
            Stocks = response.ToList();
            SpinnerVisible = false;
            StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
            LoadStocksData();
        }
    }
}