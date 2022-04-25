using Stores.Services;
using System;
using Stores.Models;
using Xunit;

namespace Stores.Tests.Services;

public class MapperTests
{
    [Fact]
    public void Can_map_from_data_dto()
    {
        // Arrange
        var mapper = new Mapper();
        var data = new StoreData
        {
            StoreId = Guid.NewGuid(),
            AccountId = Guid.NewGuid(),
            Name = "x",
            VersionNumber = 2
        };

        // Act
        var dto = mapper.Map(data);

        // Assert
        Assert.Equal(data.StoreId, dto.StoreId);
        Assert.Equal(data.AccountId, dto.AccountId);
        Assert.Equal(data.Name, dto.Name);
    }
}