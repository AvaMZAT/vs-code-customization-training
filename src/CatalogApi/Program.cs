using CatalogApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IProductService, ProductService>();

var app = builder.Build();

// GET all products
app.MapGet("/products", (IProductService products) => Results.Ok(products.GetAll()));

// GET one product by id (404 when it doesn't exist)
app.MapGet("/products/{id:int}", (int id, IProductService products) =>
    products.GetById(id) is { } product ? Results.Ok(product) : Results.NotFound());

// POST a new product
app.MapPost("/products", (CreateProduct input, IProductService products) =>
{
    var created = products.Add(input.Name, input.Price);
    return Results.Created($"/products/{created.Id}", created);
});

app.Run();

/// <summary>Request body for creating a product.</summary>
record CreateProduct(string Name, decimal Price);
