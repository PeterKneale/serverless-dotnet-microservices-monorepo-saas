using System;

namespace Stores.Models
{
    public class StoreDto
    {
        public Guid StoreId { get; init; }
        public Guid AccountId { get; init; }
        public string Name { get; init; }
    }
}