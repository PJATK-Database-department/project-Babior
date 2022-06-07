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

        public List<CompanyDto> Companies { get; set; }
        public bool SpinnerVisible { get; set; }
        public SfGrid<CompanyDto> CompanyGrid { get; set; }

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
                Debug.WriteLine("This will be displayed in output window");
                Console.WriteLine("My debug output.");
            }
            StateHasChanged();
        }
    }
}