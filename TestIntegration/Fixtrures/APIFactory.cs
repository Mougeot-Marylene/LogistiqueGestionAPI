
using LogistiqueGestion.API;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;

namespace TestIntegration.Fixtrures;


public class APIFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        base.ConfigureWebHost(builder);

        builder.ConfigureAppConfiguration((conf) =>
        {
            conf.AddJsonFile("appsettings.Integrations.json");
        });
    }
}
