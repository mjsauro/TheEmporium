using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(TheEmporium.Areas.Identity.IdentityHostingStartup))]
namespace TheEmporium.Areas.Identity
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