#pragma checksum "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/project-Babior/MarketWatch/MarketWatch/Client/Pages/Index/Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2bb5ebaf4ba0559e195352750b277f29f207d0c1"
// <auto-generated/>
#pragma warning disable 1591
namespace MarketWatch.Client.Pages.Index
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
#nullable restore
#line 1 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/project-Babior/MarketWatch/MarketWatch/Client/_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/project-Babior/MarketWatch/MarketWatch/Client/_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/project-Babior/MarketWatch/MarketWatch/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/project-Babior/MarketWatch/MarketWatch/Client/_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/project-Babior/MarketWatch/MarketWatch/Client/_Imports.razor"
using Microsoft.AspNetCore.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/project-Babior/MarketWatch/MarketWatch/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/project-Babior/MarketWatch/MarketWatch/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/project-Babior/MarketWatch/MarketWatch/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/project-Babior/MarketWatch/MarketWatch/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/project-Babior/MarketWatch/MarketWatch/Client/_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/project-Babior/MarketWatch/MarketWatch/Client/_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/project-Babior/MarketWatch/MarketWatch/Client/_Imports.razor"
using MarketWatch.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/project-Babior/MarketWatch/MarketWatch/Client/_Imports.razor"
using MarketWatch.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/project-Babior/MarketWatch/MarketWatch/Client/_Imports.razor"
using Syncfusion.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/project-Babior/MarketWatch/MarketWatch/Client/_Imports.razor"
using Syncfusion.Blazor.Data;

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/project-Babior/MarketWatch/MarketWatch/Client/_Imports.razor"
using Syncfusion.Blazor.Grids;

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/project-Babior/MarketWatch/MarketWatch/Client/_Imports.razor"
using Syncfusion.Blazor.Inputs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/project-Babior/MarketWatch/MarketWatch/Client/_Imports.razor"
using Syncfusion.Blazor.Buttons;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/project-Babior/MarketWatch/MarketWatch/Client/_Imports.razor"
using Syncfusion.Blazor.DropDowns;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/project-Babior/MarketWatch/MarketWatch/Client/_Imports.razor"
using Syncfusion.Blazor.Spinner;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/project-Babior/MarketWatch/MarketWatch/Client/_Imports.razor"
using Syncfusion.Blazor.Charts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/project-Babior/MarketWatch/MarketWatch/Client/_Imports.razor"
using Syncfusion.Blazor.Layouts;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/project-Babior/MarketWatch/MarketWatch/Client/_Imports.razor"
using Syncfusion.Blazor.Popups;

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/project-Babior/MarketWatch/MarketWatch/Client/_Imports.razor"
using MarketWatch.Shared.Dtos;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : IndexBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Authorization.AuthorizeView>(0);
            __builder.AddAttribute(1, "Authorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.OpenElement(2, "h1");
                __builder2.AddContent(3, "Hello, ");
#nullable restore
#line 6 "/Users/liza.babior/Desktop/PJATK/4 semester/APBD/Project/project-Babior/MarketWatch/MarketWatch/Client/Pages/Index/Index.razor"
__builder2.AddContent(4, authState.User.Identity.Name);

#line default
#line hidden
#nullable disable
                __builder2.AddContent(5, "!");
                __builder2.CloseElement();
                __builder2.AddMarkupContent(6, "\r\n\r\n        Welcome to your new app.\r\n    ");
            }
            ));
            __builder.AddAttribute(7, "NotAuthorized", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Authorization.AuthenticationState>)((context) => (__builder2) => {
                __builder2.AddMarkupContent(8, "\r\n        In order to use the website you have to login or register.\r\n    ");
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
