using System;
using System.Threading;
using System.Threading.Tasks;
using Amazon.Lambda.Annotations;
using Amazon.Lambda.Core;
using Stores.Exceptions;
using Stores.Models;
using Stores.Services;

namespace Stores.Functions
{
    public class GetStoreFunction
    {
        private readonly IValidator _validator;
        private readonly IMapper _mapper;
        private readonly IStorage _storage;

        public GetStoreFunction(IValidator validator, IMapper mapper, IStorage storage)
        {
            _validator = validator;
            _mapper = mapper;
            _storage = storage;
        }
        
        [LambdaFunction]
        [HttpApi(LambdaHttpMethod.Get, "/{storeId}")]
        public async Task<StoreDto> GetStore(Guid storeId, ILambdaContext context)
        {
            var cts = new CancellationTokenSource(context.RemainingTime);
            
            _validator.ValidateId(storeId);

            var store = await _storage.GetStore(storeId, cts.Token);
            
            if (store == null)
            {
                throw new StoreNotFoundException(storeId);
            }

            context.Logger.LogInformation($"Loaded store {storeId} - {store.Name}");

            return _mapper.Map(store);
        }
    }
}