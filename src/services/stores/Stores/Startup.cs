using System.Runtime.CompilerServices;
[assembly: InternalsVisibleTo("Stores.Tests")]

namespace Stores;

[LambdaStartup]
public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true)
            .AddSystemsManager("/saas/settings")
            .Build();
        services.AddSingleton<IConfiguration>(configuration);
        services.AddSingleton<IValidator, Validator>();
        services.AddSingleton<IMapper, Mapper>();
        services.AddSingleton<IStorage, Storage>();
        services.AddAWSService<IAmazonDynamoDB>();
    }
}