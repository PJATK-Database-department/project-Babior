using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MarketWatch.Client.Services;
using MarketWatch.Client.Services.Contracts;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Syncfusion.Blazor;

namespace MarketWatch.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("MarketWatch.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("MarketWatch.ServerAPI"));
            builder.Services.AddScoped<ICompanyService, CompanyService>();
            builder.Services.AddScoped<IPriceService, PriceService>();
            builder.Services.AddScoped<INewsService, NewsService>();
            builder.Services.AddMemoryCache();

            builder.Services.AddApiAuthorization();
            builder.Services.AddSyncfusionBlazor(); 
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjQ5NzQyQDMyMzAyZTMxMmUzMFBmemJXSWlIN1NUb2E5Z09BQ1lWdFAxdmxOcEhXTjZkQmFRUjNRTE9SQ2c9");
            builder.Services.AddSyncfusionBlazor(options => { options.IgnoreScriptIsolation = true; });
            
            await builder.Build().RunAsync();
        }
    }
}
