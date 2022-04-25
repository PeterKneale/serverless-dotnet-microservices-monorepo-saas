namespace Stores.Services;

public interface IMapper
{
    StoreDto Map(StoreData store);
}
    
internal class Mapper : IMapper
{
    public StoreDto Map(StoreData store) => new StoreDto
    {
        StoreId = store.StoreId,
        AccountId = store.AccountId,
        Name = store.Name
    };
}