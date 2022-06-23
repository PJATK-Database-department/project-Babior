using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MarketWatch.Client.Services.Contracts;
using MarketWatch.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
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

        [CascadingParameter] private Task<AuthenticationState> _authState { get; set; }
        
        protected AuthenticationState AuthState { get; set; }
        protected override async Task OnInitializedAsync()
        {
            AuthState = await _authState;
            SpinnerVisible = true;
            if (AuthState != null)
            {
                Companies = (await CompanyService.GetCompanies(AuthState.User.Identity.Name)).ToList();
            }

            var test = Companies;
            SpinnerVisible = false;
        }

        protected async void ActionBeginHandler(ActionEventArgs<CompanyDto> args)
        {
            if (args.RequestType.Equals(Action.Delete))
            {
                await CompanyService.DeleteCompany(args.Data.Ticker);
                if (AuthState != null)
                {
                    Companies = (await CompanyService.GetCompanies(AuthState.User.Identity.Name)).ToList();
                }
                await CompanyGrid.Refresh();
            }
            StateHasChanged();
        }
    }
}