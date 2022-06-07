using System.Collections.Generic;
using System.Linq;
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
        [Parameter] public string TickerName { get; set; }
        
        [Parameter] public EventCallback<bool> OnCompanyChosen { get; set; }
        protected SfDropDownList<string, CompanyDto> DropDownList { get; set; }
        protected bool SuccessDialogVisibility { get; set; } = false;

        protected void OnClick(MouseEventArgs args)
        {
            if (TickerName == null) return;
            CompanyService.AddCompanyByTicker(TickerName);
            SuccessDialogVisibility = true;
        }

        protected void CloseButtonClick()
        {
            SuccessDialogVisibility = false;
        }

        protected List<CompanyDto> Companies { get; set; }

        protected void OnValueSelectHandler(SelectEventArgs<CompanyDto> args)
        {
            TickerName = args.ItemData.Ticker;
            OnCompanyChosen.InvokeAsync(args.IsInteracted);
        }

        protected async Task OnFilter(FilteringEventArgs args)
        {
            args.PreventDefaultAction = true;
            if (args.Text == null) return;
            await Task.Delay(3000);
            var response = await CompanyService.GetCompaniesByName(args.Text);
            Companies = response.ToList();
        }
    }
}