using CatalogApi.Models;

namespace CatalogApi.Services;

/// <summary>In-memory product store. Data resets when the app restarts.</summary>
public class ProductService : IProductService
{
    private readonly List<Product> _products = new();
    private int _nextId = 1;

    public ProductService()
    {
        Add("Starter Widget", 9.99m);
        Add("Pro Widget", 19.99m);
    }

    public IReadOnlyList<Product> GetAll() => _products;

    public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

    public Product Add(string name, decimal price)
    {
        var product = new Product(_nextId++, name, price, DateTimeOffset.Now);
        _products.Add(product);
        return product;
    }
}
