using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(MarketWatch.Server.Areas.Identity.IdentityHostingStartup))]
namespace MarketWatch.Server.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}