using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketWatch.Client.Services.Contracts;
using MarketWatch.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace MarketWatch.Client.Pages.Dashboard
{
    public class BlogPostsBase : ComponentBase
    {
        [Inject] public INewsService NewsService { get; set; }
        [Inject] public IMessageService TickerStateService { get; set; }
        [Parameter] public string TickerName { get; set; }
        [Parameter] public bool IsCompanyChosen { get; set; }

        protected List<NewsDto> News { get; set; }

        protected override void OnInitialized()
        {
            TickerStateService.OnState += StateHandler;
        }

        private async void StateHandler()
        {
            await LoadNewsData();
        }

        private async Task LoadNewsData()
        {
            var response = await NewsService.GetNewsByTicker(TickerName);
            News = response.ToList();
        }

        protected override async Task OnInitializedAsync()
        {
            await LoadNewsData();
        }
    }
}