using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using MarketWatch.Client.Services.Contracts;
using MarketWatch.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.DropDowns;

namespace MarketWatch.Client.Pages.Dashboard
{
    public class DashboardBase : ComponentBase
    {
        [Inject] public ICompanyService CompanyService { get; set; }
        [Inject] public IMessageService TickerStateService { get; set; }
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
                _timer = new Timer(5000);
                _timer.Elapsed += TimerElapsed_TickAsync;
                _timer.Enabled = true;
                _timer.Start();
            }
        }

        protected string TickerName { get; set; }
        
        protected CompanyDto Company { get; set; }

        protected List<CompanyDto> Companies { get; set; }

        protected bool IsCompanyChosen { get; set; }

        protected void TextChanged(string ticker)
        {
            InputString = ticker;
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

        private async Task OnSearchAsync()
        {
            if (!string.IsNullOrWhiteSpace(_text))
            {
                var response = await CompanyService.GetCompaniesByName(InputString);
                Companies = response.ToList();
                await InvokeAsync(StateHasChanged);
            }
        }
        
        protected async void CompanyChosenHandler(CompanyDto company)
        {
            Company = company;
            TickerName = company.Ticker;
            IsCompanyChosen = true;
            TickerStateService.SendMessage("State Changed");
            await InvokeAsync(StateHasChanged);
        }
    }
}