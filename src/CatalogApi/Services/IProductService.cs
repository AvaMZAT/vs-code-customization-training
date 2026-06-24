using CatalogApi.Models;

namespace CatalogApi.Services;

public interface IProductService
{
    IReadOnlyList<Product> GetAll();
    Product? GetById(int id);
    Product Add(string name, decimal price);
}
