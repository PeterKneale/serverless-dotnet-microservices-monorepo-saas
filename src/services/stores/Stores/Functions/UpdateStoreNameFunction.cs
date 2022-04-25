namespace Stores.Functions;

public class UpdateStoreNameFunction
{
    private readonly IValidator _validator;
    private readonly IMapper _mapper;
    private readonly IStorage _storage;

    public UpdateStoreNameFunction(IValidator validator, IMapper mapper, IStorage storage)
    {
        _validator = validator;
        _mapper = mapper;
        _storage = storage;
    }

    [LambdaFunction]
    [HttpApi(LambdaHttpMethod.Post, "/stores/{storeId}/name")]
    public async Task<StoreDto> Execute(Guid storeId, [FromBody] string name, ILambdaContext context)
    {
        var cts = new CancellationTokenSource(context.RemainingTime);
            
        _validator.ValidateId(storeId);
        _validator.ValidateName(name);

        var store = await _storage.GetStore(storeId, cts.Token);
        if (store == null)
        {
            throw new StoreNotFoundException(storeId);
        }
            
        store.Name = name;
            
        await _storage.SaveAsync(store, cts.Token);
            
        context.Logger.LogInformation($"Saved store {storeId} - {name}");

        return _mapper.Map(store);
    }
}