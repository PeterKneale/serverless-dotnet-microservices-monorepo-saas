using Amazon.Lambda.TestUtilities;
using Moq;
using Stores.Exceptions;
using Stores.Functions;
using Stores.Models;
using Stores.Services;
using Xunit;

namespace Stores.Tests.Functions;

public class GetStoreFunctionTests
{
    private readonly Mock<IValidator> _validator;
    private readonly Mock<IMapper> _mapper;
    private readonly Mock<IStorage> _storage;
    private readonly GetStoreFunction _function;

    public GetStoreFunctionTests()
    {
        _validator = new Mock<IValidator>();
        _mapper = new Mock<IMapper>();
        _storage = new Mock<IStorage>();

        _function = new GetStoreFunction(_validator.Object, _mapper.Object, _storage.Object);
    }

    [Fact]
    public async Task Return_store()
    {
        // Arrange
        var id = Guid.NewGuid();
        _storage
            .Setup(x => x.GetStore(id, It.IsAny<CancellationToken>()))
            .Returns(Task.FromResult(new StoreData())!);
        _mapper
            .Setup(x => x.Map(It.IsAny<StoreData>()))
            .Returns(new StoreDto());

        // Act
        var result = await _function.Execute(id, new TestLambdaContext());

        // Assert
        Assert.NotNull(result);
    }

    [Fact]
    public async Task Throws_store_not_found()
    {
        // Arrange
        var id = Guid.NewGuid();

        // Act
        Task<StoreDto> Execute() => _function.Execute(id, new TestLambdaContext());

        // Assert
        await Assert.ThrowsAsync<StoreNotFoundException>(Execute);
    }
}