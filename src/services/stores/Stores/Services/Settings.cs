namespace Stores.Services;

public interface ISettings
{
    public int StoreNameMaxLength { get; }
}

internal class Settings : ISettings
{
    private readonly IConfiguration _configuration;
        
    public Settings(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public int StoreNameMaxLength => _configuration.GetValue<int>("StoreNameMaxLength");
}