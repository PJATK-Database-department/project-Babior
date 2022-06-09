using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MarketWatch.Client.Services.Contracts;
using MarketWatch.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Grids;
using Action = Syncfusion.Blazor.Grids.Action;

namespace MarketWatch.Client.Pages.Watchlist
{
    public class CompaniesBase : ComponentBase
    {
        [Inject] public ICompanyService CompanyService { get; set; }

        protected List<CompanyDto> Companies { get; set; }
        protected bool SpinnerVisible { get; set; }
        protected SfGrid<CompanyDto> CompanyGrid { get; set; }

        protected override async Task OnInitializedAsync()
        {
            SpinnerVisible = true;
            Companies = (await CompanyService.GetCompanies()).ToList();
            SpinnerVisible = false;
        }

        protected async void ActionBeginHandler(ActionEventArgs<CompanyDto> args)
        {
            if (args.RequestType.Equals(Action.Delete))
            {
                await CompanyService.DeleteCompany(args.Data.Ticker);
                Companies = (await CompanyService.GetCompanies()).ToList();
                await CompanyGrid.Refresh();
            }
            StateHasChanged();
        }
    }
}