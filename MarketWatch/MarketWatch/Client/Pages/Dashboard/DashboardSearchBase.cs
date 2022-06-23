using System.Collections.Generic;
using System.Threading.Tasks;
using MarketWatch.Client.Services.Contracts;
using MarketWatch.Shared.Dtos;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor.DropDowns;

namespace MarketWatch.Client.Pages.Dashboard
{
    public class DashboardSearchBase : ComponentBase
    {
        [Inject] public ICompanyService CompanyService { get; set; }

        [Parameter] public string InputString { get; set; }
        [Parameter] public string Ticker { get; set; }
        [Parameter] public EventCallback<string> TextChanged { get; set; }
        [Parameter] public EventCallback<CompanyDto> CompanyChosen { get; set; }
        [Parameter] public EventCallback<CompanyDto> CompanyAdd { get; set; }
        
        [Parameter] public bool IsCompanyChosen { get; set; }
        [Parameter] public List<CompanyDto> Companies { get; set; }

        protected async Task OnAddClick(MouseEventArgs args)
        {
            await InvokeAsync(async () => await CompanyAdd.InvokeAsync());
        }

        protected async Task OnFilter(FilteringEventArgs args)
        {
            args.PreventDefaultAction = true;
            if (args.Text is " " or "" or null) return;
            await InvokeAsync(async () => await TextChanged.InvokeAsync(args.Text));
        }
        
        protected async Task OnValueSelectHandler(SelectEventArgs<CompanyDto> args)
        {
            await InvokeAsync(async () => await CompanyChosen.InvokeAsync(args.ItemData));
        }
    }
}