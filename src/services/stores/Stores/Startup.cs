using Amazon.DynamoDBv2;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stores.Services;

namespace Stores
{
    [Amazon.Lambda.Annotations.LambdaStartup]
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
}
