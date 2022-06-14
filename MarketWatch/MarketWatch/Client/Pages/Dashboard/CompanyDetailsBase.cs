using MarketWatch.Shared.Dtos;
using Microsoft.AspNetCore.Components;

namespace MarketWatch.Client.Pages.Dashboard
{
    public class CompanyDetailsBase : ComponentBase
    {
        [Parameter] public CompanyDto Company { get; set; }
    }
}