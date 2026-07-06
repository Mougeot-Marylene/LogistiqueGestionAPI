
using LogistiqueGestion.API;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace TestIntegration.Fixtrures;


public class APIFactory : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureHostConfiguration(configService =>
        {
            var configRoot = new ConfigurationBuilder()
             .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "appsettings.Integrations.json"))
             .AddEnvironmentVariables()
             .Build();

            configService.AddConfiguration(configRoot);

        });

        return base.CreateHost(builder);
    }
}
