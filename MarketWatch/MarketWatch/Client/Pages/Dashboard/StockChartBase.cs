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
        
        [Inject] public IMessageService TickerStateService { get; set; }
        [Parameter] public string TickerName { get; set; }
        [Parameter] public bool IsCompanyChosen { get; set; }
        protected SfStockChart StockChart; 
        protected List<PriceDto> Stocks { get; set; } = new();

        protected bool SpinnerVisible { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            TickerStateService.OnState += StateHandler;
            await LoadStocksData();
            StockChart.Refresh();
            StateHasChanged();
        }

        private async void StateHandler(string ticker)
        {
            await LoadStocksData();
            StockChart.Refresh();
            StateHasChanged();
        }

        private async Task LoadStocksData()
        {
            //SpinnerVisible = true;
            var response = await PriceService.GetPricesByTicker(TickerName);
            if (response == null) return;
            Stocks = response.ToList();
            //SpinnerVisible = false;
        }
    }
}