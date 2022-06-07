using MarketWatch.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace MarketWatch.Client.Pages.Dashboard
{
    public class DashboardBase : ComponentBase
    {
        protected string TickerName { get; set; }
        protected bool IsCompanyChosen { get; set; } = false;

        protected void CompanyChosenHandler()
        {
            IsCompanyChosen = true;
            //StateHasChanged();
        }
    }
}