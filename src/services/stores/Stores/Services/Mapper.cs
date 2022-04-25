using Stores.Models;

namespace Stores.Services
{
    public interface IMapper
    {
        StoreDto Map(StoreData store);
        StoreData Map(StoreDto store);
    }
    
    internal class Mapper : IMapper
    {
        public StoreDto Map(StoreData store) => new StoreDto
        {
            StoreId = store.StoreId,
            AccountId = store.AccountId,
            Name = store.Name
        };
        
        public StoreData Map(StoreDto store) => new StoreData
        {
            StoreId = store.StoreId,
            AccountId = store.AccountId,
            Name = store.Name
        };
    }
}