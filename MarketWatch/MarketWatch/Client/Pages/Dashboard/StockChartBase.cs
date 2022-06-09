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
        protected List<PriceDto> Stocks { get; set; }
        private string _tickerName;

        [Parameter]
        public string TickerName
        {
            get => _tickerName;
            set
            {
                _tickerName = value;
                LoadStocksData();
            }
        }

        private bool _isCompanyChosen;

        [Parameter]
        public bool IsCompanyChosen
        {
            get => _isCompanyChosen;
            set
            {
                _isCompanyChosen = value;
                LoadStocksData();
            }
        }

        protected bool SpinnerVisible { get; set; }

        protected async void LoadStocksData()
        {
            SpinnerVisible = true;
            if (TickerName == null) return;
            var response = await PriceService.GetPricesByTicker(TickerName);
            Stocks = response.ToList();
            SpinnerVisible = false;
            StateHasChanged();
        }

        // protected override async Task OnInitializedAsync()
        // {
        //     LoadStocksData();
        // }
    }
}