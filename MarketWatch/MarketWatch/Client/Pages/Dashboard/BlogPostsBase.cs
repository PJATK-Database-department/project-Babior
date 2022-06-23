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
        [Parameter] public bool IsCompanyChosen { get; set; }

        [Parameter] public DataWrapper Data { get; set; }

        protected override void OnInitialized()
        {
            Data.News =  new List<NewsDto>();
        }

        protected override async Task OnParametersSetAsync()
        {
            //News =  (await NewsService.GetNewsCache(Ticker)).ToList();
            await base.OnParametersSetAsync();
        }
    }
}