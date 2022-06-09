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

        public string Test { get; set; }

        protected override async Task OnInitializedAsync()
        {
            TickerStateService.OnState += StateHandler;
            News =  LoadNewsData().Result.ToList();
        }

        private async void StateHandler(string message)
        {
            if (message != null)
                Test += message;
            await LoadNewsData();
            StateHasChanged();
        }

        private async Task<IEnumerable<NewsDto>> LoadNewsData()
        {
            return await NewsService.GetNewsByTicker(TickerName);
        }
    }
}