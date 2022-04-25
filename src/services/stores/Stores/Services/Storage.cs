using System;
using System.Threading;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using Stores.Models;

namespace Stores.Services
{
    public interface IStorage
    {
        Task<StoreData?> GetStore(Guid id, CancellationToken token);
        Task SaveAsync(StoreData store, CancellationToken token);
    }
    
    internal class Storage : IStorage
    {
        private readonly IDynamoDBContext _dynamo;

        public Storage(IDynamoDBContext dynamo)
        {
            _dynamo = dynamo;
        }

        public async Task<StoreData?> GetStore(Guid id, CancellationToken token) =>
            await _dynamo.LoadAsync<StoreData>(id, token);
        
        public async Task SaveAsync(StoreData store, CancellationToken token) => 
            await _dynamo.SaveAsync(store, token);
    }
}