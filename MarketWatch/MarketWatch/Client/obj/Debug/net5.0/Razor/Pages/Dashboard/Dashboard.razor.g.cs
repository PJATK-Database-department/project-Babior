#pragma checksum "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/MarketWatch/MarketWatch/Client/Pages/Dashboard/Dashboard.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6df3e7fa588ca1556d92ce1d497129a354fc1019"
// <auto-generated/>
#pragma warning disable 1591
namespace MarketWatch.Client.Pages.Dashboard
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/MarketWatch/MarketWatch/Client/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/MarketWatch/MarketWatch/Client/_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/MarketWatch/MarketWatch/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/MarketWatch/MarketWatch/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/MarketWatch/MarketWatch/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/MarketWatch/MarketWatch/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/MarketWatch/MarketWatch/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/MarketWatch/MarketWatch/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/MarketWatch/MarketWatch/Client/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/MarketWatch/MarketWatch/Client/_Imports.razor"
using MarketWatch.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/MarketWatch/MarketWatch/Client/_Imports.razor"
using MarketWatch.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/MarketWatch/MarketWatch/Client/_Imports.razor"
using Syncfusion.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/MarketWatch/MarketWatch/Client/_Imports.razor"
using Syncfusion.Blazor.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/MarketWatch/MarketWatch/Client/_Imports.razor"
using Syncfusion.Blazor.Grids;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/MarketWatch/MarketWatch/Client/_Imports.razor"
using Syncfusion.Blazor.Inputs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/MarketWatch/MarketWatch/Client/_Imports.razor"
using Syncfusion.Blazor.Buttons;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/MarketWatch/MarketWatch/Client/_Imports.razor"
using Syncfusion.Blazor.DropDowns;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/MarketWatch/MarketWatch/Client/_Imports.razor"
using Syncfusion.Blazor.Spinner;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/MarketWatch/MarketWatch/Client/_Imports.razor"
using Syncfusion.Blazor.Charts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/MarketWatch/MarketWatch/Client/_Imports.razor"
using Syncfusion.Blazor.Layouts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/MarketWatch/MarketWatch/Client/_Imports.razor"
using Syncfusion.Blazor.Popups;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/dashboard")]
    public partial class Dashboard : DashboardBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "h3");
            __builder.AddAttribute(1, "b-8711uzsbhf");
            __builder.AddContent(2, "Dashboard (");
#nullable restore
#line 4 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/MarketWatch/MarketWatch/Client/Pages/Dashboard/Dashboard.razor"
__builder.AddContent(3, IsCompanyChosen);

#line default
#line hidden
#nullable disable
            __builder.AddContent(4, ")");
            __builder.CloseElement();
            __builder.AddMarkupContent(5, "\n");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "b-8711uzsbhf");
            __builder.OpenComponent<MarketWatch.Client.Pages.Dashboard.DashboardSearch>(8);
            __builder.AddAttribute(9, "TickerName", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 6 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/MarketWatch/MarketWatch/Client/Pages/Dashboard/Dashboard.razor"
                                  TickerName

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(10, "OnCompanyChosen", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Boolean>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Boolean>(this, 
#nullable restore
#line 6 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/MarketWatch/MarketWatch/Client/Pages/Dashboard/Dashboard.razor"
                                                               CompanyChosenHandler

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(11, "\n    \n\n    ");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "class", "chart");
            __builder.AddAttribute(14, "b-8711uzsbhf");
            __builder.OpenComponent<MarketWatch.Client.Pages.Dashboard.StockChart>(15);
            __builder.AddAttribute(16, "TickerName", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 10 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/MarketWatch/MarketWatch/Client/Pages/Dashboard/Dashboard.razor"
                             TickerName

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\n\n\n");
            __builder.OpenComponent<MarketWatch.Client.Pages.Dashboard.BlogPosts>(18);
            __builder.CloseComponent();
            __builder.AddMarkupContent(19, "\n\n");
            __builder.AddMarkupContent(20, "<style b-8711uzsbhf>\n    .chart {\n        padding-top: 100px;\n    }\n</style>");
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
