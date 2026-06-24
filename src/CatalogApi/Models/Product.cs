namespace CatalogApi.Models;

/// <summary>An immutable product DTO (records are our convention for DTOs).</summary>
public record Product(int Id, string Name, decimal Price, DateTimeOffset CreatedAt);
