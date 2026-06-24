using CatalogApi.Services;
using Xunit;

namespace CatalogApi.Tests;

public class ProductServiceTests
{
    [Fact]
    public void Add_NewProduct_AssignsIncrementingId()
    {
        // Arrange
        var service = new ProductService();

        // Act
        var first = service.Add("A", 1m);
        var second = service.Add("B", 2m);

        // Assert
        Assert.Equal(first.Id + 1, second.Id);
    }

    [Fact]
    public void GetById_UnknownId_ReturnsNull()
    {
        // Arrange
        var service = new ProductService();

        // Act
        var result = service.GetById(999);

        // Assert
        Assert.Null(result);
    }
}
