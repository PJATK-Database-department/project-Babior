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
        protected List<PriceDto> Stocks { get; set; }

        protected SfStockChart StockChart { get; set; }

        protected bool SpinnerVisible { get; set; }
        
        protected bool Vis { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            SpinnerVisible = true;
            TickerStateService.OnState += StateHandler;
            //var resp = await PriceService.GetPricesByTicker(TickerName);
            //Stocks = resp == null ? new List<PriceDto>() : resp.ToList();
            Stocks = new List<PriceDto>() ;
            SpinnerVisible = false;
        }

        private async void StateHandler(string ticker)
        {
            StateHasChanged();
            SpinnerVisible = true;
            var resp = await PriceService.GetPricesByTicker(TickerName);
            Stocks = resp == null ? new List<PriceDto>() : resp.ToList();
            SpinnerVisible = false;
            StockChart?.Refresh();
            StateHasChanged();
        }

        private async Task LoadStocksData()
        {
            SpinnerVisible = true;
            var response = await PriceService.GetPricesByTicker(TickerName);
            if (response == null) return;
            Stocks = response.ToList();
            //SpinnerVisible = false;
        }
    }
}