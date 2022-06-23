using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using MarketWatch.Client.Services.Contracts;
using MarketWatch.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Caching.Memory;

namespace MarketWatch.Client.Pages.Dashboard
{
    public class DashboardBase : ComponentBase
    {
        [Inject] public ICompanyService CompanyService { get; set; }
        [Inject] public IPriceService PriceService { get; set; }
        [Inject] public INewsService NewsService { get; set; }
        [Inject] private IMemoryCache MemoryCache { get; set; }
        [CascadingParameter] private Task<AuthenticationState> _authState { get; set; }
        protected AuthenticationState AuthState { get; set; }
        protected string Ticker { get; set; }
        protected List<CompanyDto> Companies { get; set; }
        protected bool IsCompanyChosen { get; set; }
        protected DataWrapper Data { get; set; }

        private Timer _timer;

        private string _text;

        protected string InputString
        {
            get => _text;
            set
            {
                if (value == _text) return;
                _text = value;
                DisposeTimer();
                _timer = new Timer(3000);
                _timer.Elapsed += TimerElapsed_TickAsync;
                _timer.Enabled = true;
                _timer.Start();
            }
        }

        protected bool SpinnerVisible { get; set; }

        protected override async Task OnInitializedAsync()
        {
            AuthState = await _authState;
            Data = new DataWrapper()
            {
                Stocks = new List<PriceDto>(),
                News = new List<NewsDto>()
            };
            await base.OnInitializedAsync();
        }

        private async void TimerElapsed_TickAsync(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            DisposeTimer();
            await OnSearchAsync();
        }

        private void DisposeTimer()
        {
            if (_timer == null) return;
            _timer.Enabled = false;
            _timer.Elapsed -= TimerElapsed_TickAsync;
            _timer.Dispose();
            _timer = null;
        }

        protected void TextChanged(string ticker)
        {
            InputString = ticker;
        }

        private async Task OnSearchAsync()
        {
            if (!string.IsNullOrWhiteSpace(_text))
            {
                var response = await CompanyService.GetCompaniesByName(InputString);
                Companies = response.ToList();
                await InvokeAsync(StateHasChanged);
            }
        }

        protected async Task CompanyChosenHandler(CompanyDto company)
        {
            SpinnerVisible = true;
            Ticker = company.Ticker;

            var data = await GetCache(company.Ticker);

            Data = data;

            IsCompanyChosen = true;
            await InvokeAsync(StateHasChanged);
            SpinnerVisible = false;
        }

        protected void CompanyAdd()
        {
            if (Ticker == null || Data.Company == null) return;

            CompanyService.AddCompanyToWatchlist(Data.Company, AuthState.User.Identity.Name);
        }

        private async Task<DataWrapper> GetCache(string ticker)
        {
            var output = ticker is null or "" or " " ? MemoryCache.Get<DataWrapper>(ticker) : null;

            if (output is not null) return output;

            output = new DataWrapper
            {
                Company = await CompanyService.GetCompanyByTicker(ticker),
                Stocks = (await PriceService.GetPricesByTicker(ticker)).ToList(),
                News = (await NewsService.GetNewsByTicker(ticker)).ToList()
            };

            MemoryCache.Set(ticker, output, TimeSpan.FromDays(1));

            return output;
        }
    }
}