namespace Stores.Services;

public interface IValidator
{
    void ValidateId(Guid id);
    void ValidateName(string name);
}
    
internal class Validator : IValidator
{
    private readonly ISettings _settings;
        
    public Validator(ISettings settings)
    {
        _settings = settings;
    }
        
    public void ValidateId(Guid id)
    {
        if (id == Guid.Empty)
        {
            throw new ArgumentException("id is empty", nameof(id));
        }
    }
        
    public void ValidateName(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("name too short", nameof(name));
        }
        if (name.Length > _settings.StoreNameMaxLength)
        {
            throw new ArgumentException("name too long", nameof(name));
        }
    }
}