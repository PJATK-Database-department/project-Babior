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
        [Parameter] public string TickerName { get; set; }

        [Parameter] public CompanyDto Company { get; set; }
        [Parameter] public EventCallback<string> TextChanged { get; set; }
        [Parameter] public EventCallback<CompanyDto> CompanyChosen { get; set; }
        
        [Parameter] public bool IsCompanyChosen { get; set; }
        [Parameter] public List<CompanyDto> Companies { get; set; }
        protected bool SuccessDialogVisibility { get; set; }

        protected void OnAddClick(MouseEventArgs args)
        {
            if (TickerName == null) return;
            CompanyService.AddCompanyByTicker(TickerName);
            SuccessDialogVisibility = true;
        }

        protected void CloseButtonClick()
        {
            SuccessDialogVisibility = false;
        }

        protected async Task OnFilter(FilteringEventArgs args)
        {
            args.PreventDefaultAction = true;
            if (args.Text is " " or null) return;
            await InvokeAsync(async () => await TextChanged.InvokeAsync(args.Text));
        }
        
        protected async Task OnValueSelectHandler(SelectEventArgs<CompanyDto> args)
        {
            await InvokeAsync(async () => await CompanyChosen.InvokeAsync(args.ItemData));
        }
    }
}